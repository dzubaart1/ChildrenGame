using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MenuUIs
{
    public class SettingsUICntrl : MenuUIBase
    {
        [SerializeField] private Button _muteBtn;
        [SerializeField] private Button _chooseGameBtn;

        private void Awake()
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
            
        }

        private void OnClickChooseGameBtn()
        {
            if (MenuCntrl == null)
            {
                return;
            }
            
            MenuCntrl.SwitchToChooseGameUI();
        }
    }
}