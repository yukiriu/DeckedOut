using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardsHandler : MonoBehaviour, IPointerDownHandler
{
    public GameObject CardMenu;
    public void OnPointerDown(PointerEventData eventData)
    {
        CardMenu.SetActive(true);
    }
}
