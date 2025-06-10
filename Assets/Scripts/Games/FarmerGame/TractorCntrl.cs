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

        [SerializeField] private float _offset;

        public bool IsCompleted { get; private set; } = false;

        public void Update()
        {
            _progressBar.fillAmount = (_rectTransform.anchoredPosition.x + _offset) / ((RectTransform)_parentCanvas.transform).rect.width;

            if (_progressBar.fillAmount > 0.8f)
            {
                IsCompleted = true;
            }
        }

        public void FillProgressBar()
        {
            _progressBar.fillAmount = 1;
        }
    }
}