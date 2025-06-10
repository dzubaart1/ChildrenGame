using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cake : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private ECake _cakeType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _iceCreamGameUICntrl.CurrentLevel.TryComplete(ECream.No, ECup.No, _cakeType, EFruite.No);
        }
    }
}