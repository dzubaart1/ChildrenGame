using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MenuUIs
{
    public class SettingsUICntrl : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private MenuCntrl _menuCntrl;
        
        [Space]
        [Header("UIs")]
        [SerializeField] private Button _muteBtn;
        [SerializeField] private Button _chooseGameBtn;

        private void OnEnable()
        {
            _muteBtn.onClick.AddListener(OnClickMuteBtn);
            _chooseGameBtn.onClick.AddListener(OnClickChooseGameBtn);
        }

        private void OnDisable()
        {
            _muteBtn.onClick.RemoveListener(OnClickMuteBtn);
            _chooseGameBtn.onClick.RemoveListener(OnClickChooseGameBtn);
        }

        private void OnClickMuteBtn()
        {
            SoundManager soundManager = SoundManager.Instance;
            if (soundManager == null)
            {
                return;
            }
            
            soundManager.ToggleMute();
        }

        private void OnClickChooseGameBtn()
        {
            _menuCntrl.SwitchToChooseGameUI();
        }
    }
}