using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class TouchController : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        public static event Action<Vector3> OnPlayerDragged;

        private UnityEngine.Camera mainCam;
        private Vector3 lastDragWorldPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            lastDragWorldPosition = ConvertScreenToWorldPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var currentDragWorldPosition = ConvertScreenToWorldPosition(eventData);
            
            OnPlayerDragged?.Invoke(currentDragWorldPosition - lastDragWorldPosition);

            lastDragWorldPosition = currentDragWorldPosition;
        }

        private Vector3 ConvertScreenToWorldPosition(PointerEventData eventData)
        {
            var screenPos = new Vector3(eventData.position.x, eventData.position.y, mainCam.nearClipPlane);

            return mainCam.ScreenToWorldPoint(screenPos);
        }

        private void OnEnable()
        {
            mainCam = UnityEngine.Camera.main;
            
            if (mainCam != null) {return;}
            
            Debug.LogError("Tag the main camera.");
        }

        private void OnDisable()
        {
            mainCam = null;
        }
    }
}
