using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Games.TrainGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [SerializeField] private TrainGameUICntrl _trainGameUICntrl;
        [SerializeField] private Socket[] _sockets;

        public bool IsLevelCompleted { get; private set; }
        
        private void Update()
        {
            if (!IsLevelCompleted)
            {
                if (_sockets.All(socket => socket.IsActivated))
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
            _trainGameUICntrl.SwitchToNextLevel();
        }
    }
}