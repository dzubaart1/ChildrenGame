using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools
{
    public class DraggableUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Canvas parentCanvas;
        
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentCanvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out pos);
            rectTransform.anchoredPosition = pos;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}