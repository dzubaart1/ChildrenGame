using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cup : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private LevelCntrl _levelCntrl;
        [SerializeField] private ECup _cupType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _levelCntrl.TryComplete(ECream.No, _cupType, ECake.No, EFruite.No);
        }
    }
}