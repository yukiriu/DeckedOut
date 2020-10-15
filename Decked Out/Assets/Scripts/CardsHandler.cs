using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardsHandler : MonoBehaviour, IPointerDownHandler
{
    public GameObject CardMenu;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!CardMenu.active)
        {
            CardMenu.SetActive(true);
            Card card = gameObject.GetComponent<Card>();
            TextMeshProUGUI cardName = GameObject.Find("CardName").GetComponent<TextMeshProUGUI>();
            Image cardImage = GameObject.Find("CardImage").GetComponent<Image>();
            TextMeshProUGUI cardDescription = GameObject.Find("CardDescription").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardAtk = GameObject.Find("ATK").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardType = GameObject.Find("TYPE").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardAtkSpeed = GameObject.Find("ATKSPEED").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardTarget = GameObject.Find("TARGET").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardAbility = GameObject.Find("ABILITY").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI cardAbilityDmg = GameObject.Find("ABILITYDMG").GetComponent<TextMeshProUGUI>();
            cardName.text = card.Name;
            cardDescription.text = "";
            cardAtk.text = card.CardAtk();
            cardType.text = card.CardType();
            cardAtkSpeed.text = card.CardAtkSpeed();
            cardTarget.text = card.CardTarget();
            cardAbility.text = card.CardAbility();
            cardAbilityDmg.text = card.CardAbilityDmg();
            cardImage.color = card.GetComponent<Image>().color;
        }
    }
}
