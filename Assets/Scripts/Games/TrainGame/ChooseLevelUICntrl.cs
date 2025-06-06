using System;
using UnityEngine;
using UnityEngine.UI;

namespace Games.TrainGame
{
    public class ChooseLevelUICntrl : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private TrainGameUICntrl _trainGameUICntrl;
        
        [Space]
        [Header("UIs")]
        [SerializeField] private Button _firstLevelBtn;
        [SerializeField] private Button _secondLevelBtn;
        [SerializeField] private Button _thirdLevelBtn;
        [SerializeField] private Button _forthLevelBtn;

        private void OnEnable()
        {
            _firstLevelBtn.onClick.AddListener(OnClickFirstLevelBtn);
            _secondLevelBtn.onClick.AddListener(OnClickSecondLevelBtn);
            _thirdLevelBtn.onClick.AddListener(OnClickThirdLevelBtn);
            _forthLevelBtn.onClick.AddListener(OnClickFourthLevelBtn);
        }

        private void OnDisable()
        {
            _firstLevelBtn.onClick.RemoveListener(OnClickFirstLevelBtn);
            _secondLevelBtn.onClick.RemoveListener(OnClickSecondLevelBtn);
            _thirdLevelBtn.onClick.RemoveListener(OnClickThirdLevelBtn);
            _forthLevelBtn.onClick.RemoveListener(OnClickFourthLevelBtn);
        }

        private void OnClickFirstLevelBtn()
        {
            Debug.Log("CLICKED 1 BTN");
            _trainGameUICntrl.SwitchToFirstLevelUI();
        }
        
        private void OnClickSecondLevelBtn()
        {
            _trainGameUICntrl.SwitchToSecondLevelUI();   
        }
        
        private void OnClickThirdLevelBtn()
        {
            _trainGameUICntrl.SwitchToThirdLevelUI();
        }
        
        private void OnClickFourthLevelBtn()
        {
            _trainGameUICntrl.SwitchToFourthLevelUI();
        }
    }
}