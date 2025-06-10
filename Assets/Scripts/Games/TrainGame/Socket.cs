using System;
using UnityEngine;
using UnityEngine.UI;

namespace Games.TrainGame
{
    public class Socket : MonoBehaviour
    {
        public bool IsActivated { get; private set; } = false;

        [SerializeField] private Plug _targetPlug;
        [SerializeField] private Image _image;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("ENTER");
            Plug plug = other.GetComponentInChildren<Plug>();

            if (plug == null)
            {
                return;
            }

            if (plug != _targetPlug)
            {
                return;
            }
            
            OnPlugEntered(plug.transform);
        }

        private void OnPlugEntered(Transform plug)
        {
            IsActivated = true;
            _image.color = Color.white;
            plug.gameObject.SetActive(false);
        }
    }
}