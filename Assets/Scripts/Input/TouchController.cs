using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class TouchController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerExitHandler
    {
        public static event Action OnPlayerTapped;
        public static event Action OnPlayerDragged;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnPlayerTapped?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}
