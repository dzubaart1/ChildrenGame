using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Games.IceCreamGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [Serializable]
        private struct Step
        {
            public ECream CreamType;
            public ECake CakeType;
            public EFruite FruiteType;
            public ECup CupType;
            public Image Image;

            public bool EqualsStep(ECream cream, ECake cake, EFruite fruite, ECup cup)
            {
                return CreamType == cream && CakeType == cake && FruiteType == fruite && CupType == cup;
            }
        }

        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private Step[] _steps;

        public bool IsLevelCompleted { get; private set; }
        
        private int _currentStep = 0;

        private void Start()
        {
            foreach (var step in _steps)
            {
                Color targetColor = step.Image.color;
                targetColor.a = 0.5f;

                step.Image.color = targetColor;
            }
        }

        public void TryComplete(ECream cream, ECup cup, ECake cake, EFruite fruite)
        {
            if (!_steps[_currentStep].EqualsStep(cream, cake, fruite, cup))
            {
                return;
            }

            Color targetColor = _steps[_currentStep].Image.color;
            targetColor.a = 1f;
            _steps[_currentStep].Image.color = targetColor;
            
            if (_currentStep + 1 == _steps.Length)
            {
                IsLevelCompleted = true;
                StartCoroutine(OnCompleteLevel());
                return;
            }
            else
            {
                _currentStep++;
            }
        }

        private IEnumerator OnCompleteLevel()
        {
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

            IsLevelCompleted = true;
            
            effectsManager.StartCongratulations();
            soundManager.PlayAdditionalSound(ESound.Success);
            yield return new WaitForSeconds(2f);
            _iceCreamGameUICntrl.SwitchToNextLevelUI();
        }
    }
}