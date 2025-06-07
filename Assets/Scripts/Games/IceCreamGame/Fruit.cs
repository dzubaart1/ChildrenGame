using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Fruit : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private LevelCntrl _levelCntrl;
        [SerializeField] private EFruite _fruiteType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _levelCntrl.TryComplete(ECream.No, ECup.No, ECake.No, _fruiteType);
        }
    }
}