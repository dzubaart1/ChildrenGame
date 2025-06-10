using System.Linq;
using DefaultNamespace;
using JetBrains.Annotations;
using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.BackingGame
{
    public class Spawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Refs")]
        [SerializeField] private Canvas _parentCanvas;
        [SerializeField] private RectTransform _spawnersHolder;
        
        [Space]
        [Header("Configs")]
        [SerializeField] private MealConfig _mealConfig;
        [SerializeField] private Meal _mealPrefab;

        [CanBeNull] private Meal _currentMeal;
        
        private Vector2 _startPos;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Camera.main == null)
            {
                return;
            }
            
            SoundManager soundManager = SoundManager.Instance;
            if (soundManager == null)
            {
                return;
            }
            
            Meal meal = Instantiate(_mealPrefab, _spawnersHolder);
            meal.Init(_mealConfig);

            RectTransform rectTransform = meal.GetComponentInChildren<RectTransform>();
            if (rectTransform == null)
            {
                return;
            }
            
            DraggableUI draggableUI = meal.GetComponentInChildren<DraggableUI>();
            if (draggableUI == null)
            {
                return;
            }
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentCanvas.transform as RectTransform, 
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 pos);
            rectTransform.anchoredPosition = pos;
            
            draggableUI.ForceSetDragStatus(EDragStatus.Drag);
            soundManager.PlayAdditionalSound(ESound.BeginDrag);
            
            _startPos = pos;
            _currentMeal = meal;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_parentCanvas == null)
            {
                return;
            }

            if (_currentMeal == null)
            {
                return;
            }
            
            RectTransform rectTransform = _currentMeal.GetComponentInChildren<RectTransform>();
            if (rectTransform == null)
            {
                return;
            }
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentCanvas.transform as RectTransform, 
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 pos);
            rectTransform.anchoredPosition = pos;
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            if (_currentMeal == null)
            {
                return;
            }

            DraggableUI draggableUI = _currentMeal.GetComponentInChildren<DraggableUI>();
            if (draggableUI == null)
            {
                return;
            }

            foreach (var collider in draggableUI.CollideWith)
            {
                Grill grill = collider.GetComponentInChildren<Grill>();
                if (grill != null)
                {
                    draggableUI.ForceSetDragStatus(EDragStatus.EndDrag);
                    grill.AddMealToGrill(_currentMeal);
                 
                    _currentMeal = null;
                    return;
                }
            }
            
            Destroy(_currentMeal.gameObject);
        }
    }
}