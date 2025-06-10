using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

namespace Games.TrainGame
{
    public class TrainGameUICntrl : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private List<LevelCntrl> _levelCntrls;
        
        [CanBeNull] private LevelCntrl _currentLevel;

        private int _currentLevelID = 0;
        private bool _isGameFinished = false;
        
        private void Start()
        {
            foreach (var level in _levelCntrls)
            {
                level.gameObject.SetActive(false);
            }
            
            _currentLevelID = 0;
            
            LevelCntrl levelCntrl = _levelCntrls[_currentLevelID];
            levelCntrl.gameObject.SetActive(true);
            
            _currentLevel = levelCntrl;
        }
        
        private void Update()
        {
            if (!_isGameFinished)
            {
                if (_levelCntrls.All(level => level.IsLevelCompleted))
                {
                    _isGameFinished = true;
                    StartCoroutine(OnGameFinished());
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
            
            if (_currentLevel != null)
            {
                _currentLevel.gameObject.SetActive(false);
            }

            if (_currentLevelID + 1 == _levelCntrls.Count)
            {
                gameManager.StartMenuScene();
                return;
            }

            LevelCntrl levelCntrl = _levelCntrls[++_currentLevelID];
            levelCntrl.gameObject.SetActive(true);
            
            _currentLevel = levelCntrl;
        }
        
        private IEnumerator OnGameFinished()
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
            yield return new WaitForSeconds(1f);
        
            gameManager.StartMenuScene();
        }
    }
}