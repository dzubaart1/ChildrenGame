using JetBrains.Annotations;
using UnityEngine;

namespace Games.TrainGame
{
    public class TrainGameUICntrl : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private RectTransform _firstLevelUI;
        [SerializeField] private RectTransform _secondLevelUI;
        [SerializeField] private RectTransform _thirdLevelUI;
        [SerializeField] private RectTransform _fourthLevelUI;

        [Space]
        [Header("Others")]
        [SerializeField] private RectTransform _chooseLevelUI;
        [SerializeField] private RectTransform _defaultUI;
        
        [CanBeNull] private RectTransform _currentUI;

        private void Start()
        {
            _firstLevelUI.gameObject.SetActive(false);
            _secondLevelUI.gameObject.SetActive(false);
            _thirdLevelUI.gameObject.SetActive(false);
            _fourthLevelUI.gameObject.SetActive(false);
            _chooseLevelUI.gameObject.SetActive(false);
            
            _defaultUI.gameObject.SetActive(true);
            _currentUI = _defaultUI;
        }

        public void SwitchToChooseLevelUI()
        {
            if (_currentUI != null)
            {
                _currentUI.gameObject.SetActive(false);
            }

            _chooseLevelUI.gameObject.SetActive(true);
            _currentUI = _chooseLevelUI;
        }
        
        public void SwitchToFirstLevelUI()
        {
            if (_currentUI != null)
            {
                _currentUI.gameObject.SetActive(false);
            }

            _firstLevelUI.gameObject.SetActive(true);
            _currentUI = _firstLevelUI;
        }
        
        public void SwitchToSecondLevelUI()
        {
            if (_currentUI != null)
            {
                _currentUI.gameObject.SetActive(false);
            }

            _secondLevelUI.gameObject.SetActive(true);
            _currentUI = _secondLevelUI;
        }
        
        public void SwitchToThirdLevelUI()
        {
            if (_currentUI != null)
            {
                _currentUI.gameObject.SetActive(false);
            }

            _thirdLevelUI.gameObject.SetActive(true);
            _currentUI = _thirdLevelUI;
        }
        
        public void SwitchToFourthLevelUI()
        {
            if (_currentUI != null)
            {
                _currentUI.gameObject.SetActive(false);
            }

            _fourthLevelUI.gameObject.SetActive(true);
            _currentUI = _fourthLevelUI;
        }
    }
}