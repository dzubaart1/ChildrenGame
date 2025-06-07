using UnityEngine;
using UnityEngine.UI;

namespace Games.FarmerGame
{
    public class TractorCntrl : MonoBehaviour
    {
        [Space]
        [Header("UIs")]
        [SerializeField] private Image _progressBar;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Canvas _parentCanvas;

        public bool IsCompleted { get; private set; } = false;

        public void Update()
        {
            _progressBar.fillAmount = _rectTransform.anchoredPosition.x / ((RectTransform)_parentCanvas.transform).rect.width;

            if (_progressBar.fillAmount > 0.8f)
            {
                IsCompleted = true;
            }
        }
    }
}