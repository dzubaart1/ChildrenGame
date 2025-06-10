using System;
using System.Collections;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Games.BackingGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [SerializeField] private BackingGameUICntrl _backingGameUICntrl;
        
        [SerializeField] private Eater[] _eaters;
        
        public bool IsLevelCompleted { get; private set; }
        
        private void Update()
        {
            if (!IsLevelCompleted)
            {
                if (_eaters.All(eater => eater.IsEated))
                {
                    IsLevelCompleted = true;
                    StartCoroutine(OnLevelFinished());
                }
            }
        }

        private IEnumerator OnLevelFinished()
        {
            GameManager gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                yield break;
            }
            
            EffectsManager effectsManager = EffectsManager.Instance;
            if (effectsManager == null)
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
            _backingGameUICntrl.SwitchToNextLevelUI();
        }
    }
}