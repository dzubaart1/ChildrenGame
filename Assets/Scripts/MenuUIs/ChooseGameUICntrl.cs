using UnityEngine;
using UnityEngine.UI;

namespace MenuUIs
{
    public class ChooseGameUICntrl : MonoBehaviour
    {
        [Header("Game Btns")]
        [SerializeField] private Button _trainGameBtn;
        [SerializeField] private Button _fireFighterGameBtn;
        [SerializeField] private Button _backingGameBtn;
        [SerializeField] private Button _iceCreamGameBtn;
        [SerializeField] private Button _farmerGameBtn;

        private void OnEnable()
        {
            _trainGameBtn.onClick.AddListener(OnClickTrainGameBtn);
            _fireFighterGameBtn.onClick.AddListener(OnClickFireFighterGameBtn);
            _backingGameBtn.onClick.AddListener(OnClickBackingGameBtn);
            _iceCreamGameBtn.onClick.AddListener(OnClickIceCreamGameBtn);
            _farmerGameBtn.onClick.AddListener(OnClickFarmerGameBtn);
        }

        private void OnDisable()
        {
            _trainGameBtn.onClick.RemoveListener(OnClickTrainGameBtn);
            _fireFighterGameBtn.onClick.RemoveListener(OnClickFireFighterGameBtn);
            _backingGameBtn.onClick.RemoveListener(OnClickBackingGameBtn);
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