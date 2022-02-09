using System;
using UnityEngine;

namespace PickUps
{
    public class GreenBottle : MonoBehaviour
    {
        public static event Action OnGreenBottlePickedUp;

        private int ballLayer;

        private void OnEnable()
        {
            ballLayer = LayerMask.NameToLayer("Ball");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != ballLayer) {return;}
        
            OnGreenBottlePickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
