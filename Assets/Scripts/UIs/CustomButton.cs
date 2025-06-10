using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace.UIs
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : MonoBehaviour
    {
        [SerializeField] private ESound _soundType;

        [CanBeNull] private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (_button == null)
            {
                return;
            }
            
            _button.onClick.AddListener(OnBtnClicked);
        }

        private void OnDisable()
        {
            if (_button == null)
            {
                return;
            }
            
            _button.onClick.RemoveListener(OnBtnClicked);
        }

        private void OnBtnClicked()
        {
            SoundManager soundManager = SoundManager.Instance;
            if (soundManager == null)
            {
                return;
            }
            
            soundManager.PlayAdditionalSound(_soundType);            
        }
    }
}