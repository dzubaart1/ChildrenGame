using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Games.FireFighterGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private FireFighterGameUICntrl _fireFighterGameUICntrl;
        [SerializeField] private PlaceHolder _placeHolder;

        public bool IsLevelCompleted { get; private set; }

        private void Update()
        {
            if (!IsLevelCompleted)
            {
                if (_placeHolder.IsActivated)
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
            _fireFighterGameUICntrl.SwitchToNextLevelUI();
        }
    }
}