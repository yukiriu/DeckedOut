﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardsHandler : MonoBehaviour, IPointerDownHandler
{
    public GameObject[] CardsPrefabs;
    public GameObject CardMenu;
    public GameObject Deck;
    static GameObject lastCardClicked = null;

    private static List<GameObject> selectedCards = new List<GameObject>();

    private static bool loaded = false;

    void Start()
    {
        CardsPrefabs = Resources.LoadAll<GameObject>("Cards");

        selectedCards.RemoveAll(item => item == null);
        loadDeckFromPrefs();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Card"))
        {
            if (!selectedCards.Any(c => c.name.Contains(obj.name)))
                selectedCards.Add(obj);
        }
    }

    public static void ChangedScene()
    {
        loaded = false;
    }
    public void ChooseCard()
    {
        lastCardClicked = gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Card" && lastCardClicked != null)
        {
            replaceCard(eventData);
            saveDeck();
        }
        else if (!CardMenu.active && eventData.pointerCurrentRaycast.gameObject.tag == "AcquiredCard")
        {
            showCardInfo();
        }

        lastCardClicked = null;
        selectedCards.RemoveAll(item => item == null);
    }

    private void saveDeck()
    {
        int i = 1;
        foreach(GameObject card in selectedCards)
        {
            PlayerPrefs.SetString("Card" + i, card.name);
            i++;
        }
        PlayerPrefs.Save();
    }

    private void loadDeckFromPrefs()
    {
        if (!loaded)
        {
            for (int i = 1; i <= 5; i++)
            {
                GameObject oldCard = GameObject.Find("Card" + i);

                float x = oldCard.GetComponent<RectTransform>().position.x;
                float y = oldCard.GetComponent<RectTransform>().position.y;

                GameObject toCreate = null;
                foreach (GameObject card in CardsPrefabs)
                {
                    if (card.name.Contains(PlayerPrefs.GetString("Card" + i)))
                        toCreate = card;
                }

                Destroy(oldCard);

                GameObject createdCard = Instantiate(toCreate, new Vector2(x, y), Quaternion.identity);
                createdCard.transform.SetParent(Deck.transform);
                createdCard.name = toCreate.name;

                createdCard.GetComponent<CardsHandler>().CardMenu = GameObject.FindGameObjectWithTag("CardMenu");
                createdCard.GetComponent<CardsHandler>().Deck = GameObject.FindGameObjectWithTag("Deck");
                createdCard.tag = "Card";

                selectedCards.Add(createdCard);
            }
            loaded = true;
        }
    }
    private void showCardInfo()
    {
        CardMenu.SetActive(true);
        Card card = gameObject.GetComponent<Card>();
        lastCardClicked = gameObject;
        GameObject.Find("CardName").GetComponent<TextMeshProUGUI>().text = card.Name;
        Image cardImage = GameObject.Find("CardImage").GetComponent<Image>();
        GameObject.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("ATK").GetComponent<TextMeshProUGUI>().text = card.CardAtk();
        GameObject.Find("TYPE").GetComponent<TextMeshProUGUI>().text = card.CardType();
        GameObject.Find("ATKSPEED").GetComponent<TextMeshProUGUI>().text = card.CardAtkSpeed();
        GameObject.Find("TARGET").GetComponent<TextMeshProUGUI>().text = card.CardTarget();
        GameObject.Find("ABILITY").GetComponent<TextMeshProUGUI>().text = card.CardAbility();
        GameObject.Find("ABILITYDMG").GetComponent<TextMeshProUGUI>().text = card.CardAbilityDmg();
        GameObject.Find("UseButton").GetComponent<Button>().onClick.AddListener(delegate { ChooseCard(); });
        cardImage.color = card.GetComponent<Image>().color;
    }

    private void replaceCard(PointerEventData eventData)
    {
        float x = 0;
        float y = 0;

        GameObject oldCard = GameObject.Find(eventData.pointerCurrentRaycast.gameObject.name);
        x = oldCard.GetComponent<RectTransform>().position.x;
        y = oldCard.GetComponent<RectTransform>().position.y;

        GameObject toCreate = null;
        foreach (GameObject card in CardsPrefabs)
        {
            if (lastCardClicked.name.Contains(card.name))
                toCreate = card;
        }

        if (!selectedCards.Any(c => c.name.Contains(toCreate.name)))
        {
            int index = selectedCards.FindIndex(a => a.name == oldCard.name);
            Destroy(oldCard);
            GameObject createdCard = Instantiate(toCreate, new Vector2(x, y), Quaternion.identity);
            createdCard.transform.SetParent(Deck.transform);
            createdCard.name = toCreate.name;
            createdCard.GetComponent<Image>().color = lastCardClicked.GetComponent<Image>().color;

            createdCard.GetComponent<CardsHandler>().CardMenu = GameObject.FindGameObjectWithTag("CardMenu");
            createdCard.GetComponent<CardsHandler>().Deck = GameObject.FindGameObjectWithTag("Deck");
            createdCard.tag = "Card";

            selectedCards[index] = createdCard;
        }
    }
}
