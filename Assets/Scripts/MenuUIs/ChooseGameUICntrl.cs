using System;
using UnityEngine;
using UnityEngine.UI;

namespace MenuUIs
{
    public class ChooseGameUICntrl : MenuUIBase
    {
        [Header("UI Btns")]
        [SerializeField] private Button _prevPageBtn;
        [SerializeField] private Button _nextPageBtn;

        [Space]
        [Header("Game Btns")]
        [SerializeField] private Button _trainGameBtn;
        [SerializeField] private Button _fireFighterGameBtn;
        [SerializeField] private Button _backingGameBtn;
        [SerializeField] private Button _fishingGameBtn;
        [SerializeField] private Button _iceCreamGameBtn;
        [SerializeField] private Button _farmerGameBtn;

        private void Awake()
        {
            _trainGameBtn.onClick.AddListener(OnClickTrainGameBtn);
            _fireFighterGameBtn.onClick.AddListener(OnClickFireFighterGameBtn);
            _backingGameBtn.onClick.AddListener(OnClickBackingGameBtn);
            _fishingGameBtn.onClick.AddListener(OnClickFishingGameBtn);
            _iceCreamGameBtn.onClick.AddListener(OnClickIceCreamGameBtn);
            _farmerGameBtn.onClick.AddListener(OnClickFarmerGameBtn);
        }

        private void OnDisable()
        {
            _trainGameBtn.onClick.RemoveListener(OnClickTrainGameBtn);
            _fireFighterGameBtn.onClick.RemoveListener(OnClickFireFighterGameBtn);
            _backingGameBtn.onClick.RemoveListener(OnClickBackingGameBtn);
            _fishingGameBtn.onClick.RemoveListener(OnClickFishingGameBtn);
            _iceCreamGameBtn.onClick.RemoveListener(OnClickIceCreamGameBtn);
            _farmerGameBtn.onClick.RemoveListener(OnClickFarmerGameBtn);
        }

        private void OnClickTrainGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartTrainGameScene();
        }
        
        private void OnClickFireFighterGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartFireFighterGameScene();
        }
        
        private void OnClickBackingGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartBackingGameScene();
        }
        
        private void OnClickFishingGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartFishingGameScene();
        }
        
        private void OnClickIceCreamGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartIceCreamGameScene();
        }
        
        private void OnClickFarmerGameBtn()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            gameManager.StartFarmerGameScene();
        }
    }
}