using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.IceCreamGame
{
    public class Cake : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private LevelCntrl _levelCntrl;
        [SerializeField] private ECake _cakeType;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _levelCntrl.TryComplete(ECream.No, ECup.No, _cakeType, EFruite.No);
        }
    }
}