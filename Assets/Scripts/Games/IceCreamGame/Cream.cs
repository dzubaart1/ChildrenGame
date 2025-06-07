using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cream : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private LevelCntrl _levelCntrl;
        [SerializeField] private ECream _creamType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _levelCntrl.TryComplete(_creamType, ECup.No, ECake.No, EFruite.No);
        }
    }
}