using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cream : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private ECream _creamType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _iceCreamGameUICntrl.CurrentLevel.TryComplete(_creamType, ECup.No, ECake.No, EFruite.No);
        }
    }
}