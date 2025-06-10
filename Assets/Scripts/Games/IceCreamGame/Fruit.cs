using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Fruit : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private EFruite _fruiteType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _iceCreamGameUICntrl.CurrentLevel.TryComplete(ECream.No, ECup.No, ECake.No, _fruiteType);
        }
    }
}