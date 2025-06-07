using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Tools
{
    public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("UIs")]
        [FormerlySerializedAs("rectTransform")] [SerializeField] private RectTransform _rectTransform;
        
        [Space]
        [Header("Configs")]
        [SerializeField] private bool _isComeBackToStartPos = false;
        [SerializeField] private bool _constaintsX = false;
        [SerializeField] private bool _constaintsY = false;

        [CanBeNull] private Canvas _parentCanvas;

        public EDragStatus DragStatus = EDragStatus.EndDrag;
        public IReadOnlyList<Collider2D> CollideWith => _collideWith;
        private List<Collider2D> _collideWith = new List<Collider2D>();
        
        private Vector2 _startPos;

        private void Awake()
        {
            _parentCanvas = transform.GetComponentInParent<Canvas>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_collideWith.Contains(other))
            {
                _collideWith.Add(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _collideWith.Remove(other);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_parentCanvas == null)
            {
                return;
            }
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentCanvas.transform as RectTransform, 
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 pos);
            
            _rectTransform.anchoredPosition = new Vector2
            (
                _constaintsY ? _rectTransform.anchoredPosition.x : pos.x,
                _constaintsX ? _rectTransform.anchoredPosition.y : pos.y
                );

            DragStatus = EDragStatus.Drag;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isComeBackToStartPos)
            {
                _startPos = _rectTransform.anchoredPosition;
            }
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isComeBackToStartPos)
            {
                _rectTransform.anchoredPosition = _startPos;
            }

            DragStatus = EDragStatus.EndDrag;
        }

        public void ForceSetDragStatus(EDragStatus dragStatus)
        {
            DragStatus = dragStatus;
        }
    }
}