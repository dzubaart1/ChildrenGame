using System;
using System.Collections;
using System.Linq;
using DefaultNamespace;
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
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                return;
            }
            
            if (_currentLevelID + 1 == _levels.Length)
            {
                StartCoroutine(OnFinishGame());
                gameManager.StartMenuScene();
                return;
            }

            if (CurrentLevel != null)
            {
                CurrentLevel.OnFinishLevel();
            }
            
            CurrentLevel = _levels[++_currentLevelID];
            CurrentLevel.OnStartLevel();
        }

        private IEnumerator OnFinishGame()
        {
            EffectsManager effectsManager = EffectsManager.Instance;
            if (effectsManager == null)
            {
                yield break;
            }
        
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                yield break;
            }
            
            SoundManager soundManager = SoundManager.Instance;
            if (soundManager == null)
            {
                yield break;
            }
        
            effectsManager.StartCongratulations();
            soundManager.PlayAdditionalSound(ESound.Success);
            yield return new WaitForSeconds(2f);
        
            gameManager.StartMenuScene();
        }
    }
}