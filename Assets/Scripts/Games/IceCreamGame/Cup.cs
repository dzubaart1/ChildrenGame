using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cup : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private ECup _cupType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _iceCreamGameUICntrl.CurrentLevel.TryComplete(ECream.No, _cupType, ECake.No, EFruite.No);
        }
    }
}