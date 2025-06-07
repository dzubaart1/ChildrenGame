using System;
using UnityEngine;
using UnityEngine.UI;

namespace Games.FarmerGame
{
    public class FarmerGameUICntrl : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private FarmerGame _farmerGame;
        
        [Space]
        [Header("UIs")]
        [SerializeField] private Button _nextLevelBtn;

        private void Start()
        {
            Canvas canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
        }

        private void Update()
        {
            _nextLevelBtn.gameObject.SetActive(_farmerGame.CurrentLevel == null || _farmerGame.CurrentLevel.IsCompleted); 
        }

        private void OnEnable()
        {
            _nextLevelBtn.onClick.AddListener(OnClickNextLevelBtn);
        }

        private void OnDisable()
        {
            _nextLevelBtn.onClick.RemoveListener(OnClickNextLevelBtn);
        }

        private void OnClickNextLevelBtn()
        {
            _farmerGame.SwitchToNextLevel();
        }
    }
}