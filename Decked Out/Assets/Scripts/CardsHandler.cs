using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardsHandler : MonoBehaviour, IPointerDownHandler
{
    public GameObject CardMenu;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!CardMenu.active)
        {
            CardMenu.SetActive(true);
        }
    }
}
