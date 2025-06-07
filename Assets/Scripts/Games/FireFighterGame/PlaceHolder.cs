using System.Linq;
using Tools;
using UnityEngine;

namespace Games.FireFighterGame
{
    public class PlaceHolder : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private Plug[] _correctPlugs;

        [Space]
        [Header("UIs")]
        [SerializeField] private Transform _parent;
        
        public bool IsActivated { get; private set; } = false;
        
        private int _plugsEnteredCount = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Plug plug = other.GetComponentInChildren<Plug>();
            if (plug == null)
            {
                return;
            }

            if (!_correctPlugs.Contains(plug))
            {
                return;
            }
            
            OnPlugEntered(plug);
        }

        private void OnPlugEntered(Plug plug)
        {
            DraggableUI draggableUI = plug.GetComponentInChildren<DraggableUI>();
            if (draggableUI == null)
            {
                return;
            }

            draggableUI.enabled = false;
            plug.transform.SetParent(_parent);
            
            if (++_plugsEnteredCount == _correctPlugs.Length)
            {
                IsActivated = true;
            }
        }
    }
}