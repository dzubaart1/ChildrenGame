using System;
using System.Linq;
using Games.FarmerGame.Levels;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Games.FarmerGame
{
    public class FarmerGame : MonoBehaviour
    {
        [SerializeField] private BaseLevel[] _levels;
        [SerializeField] private BaseLevel _defaultLevel;
        
        [CanBeNull] public BaseLevel CurrentLevel { get; private set; }

        private int _currentLevelID = 0;

        private void Start()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                if (_defaultLevel == _levels[i])
                {
                    _currentLevelID = i;
                    
                    CurrentLevel = _defaultLevel;
                    CurrentLevel.OnStartLevel();
                    return;
                }
            }
        }

        public void SwitchToNextLevel()
        {
            if (_currentLevelID + 1 == _levels.Length)
            {
                return;
            }

            if (CurrentLevel != null)
            {
                CurrentLevel.OnFinishLevel();
            }
            
            CurrentLevel = _levels[++_currentLevelID];
            CurrentLevel.OnStartLevel();
        }
    }
}