using System;
using UnityEngine;

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

            public bool EqualsStep(ECream cream, ECake cake, EFruite fruite, ECup cup)
            {
                return CreamType == cream && CakeType == cake && FruiteType == fruite && CupType == cup;
            }
        }
        
        public bool IsCompleted { get; private set; } = false;

        [SerializeField] private IceCreamGameUICntrl _iceCreamGameUICntrl;
        [SerializeField] private Step[] _steps;

        private int _currentStep = 0;
        
        public void TryComplete(ECream cream, ECup cup, ECake cake, EFruite fruite)
        {
            if (!_steps[_currentStep].EqualsStep(cream, cake, fruite, cup))
            {
                return;
            }

            if (_currentStep + 1 == _steps.Length)
            {
                IsCompleted = true;
                _iceCreamGameUICntrl.SwitchToNextLevelUI();
                return;
            }

            _currentStep++;
        }
    }
}