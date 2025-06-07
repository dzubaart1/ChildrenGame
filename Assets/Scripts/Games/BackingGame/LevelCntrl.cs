using System;
using System.Linq;
using UnityEngine;

namespace Games.BackingGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [SerializeField] private BackingGameUICntrl _backingGameUICntrl;
        
        [SerializeField] private Eater[] _eaters;
        
        private bool _isGameFinished = false;
        
        private void Update()
        {
            if (!_isGameFinished)
            {
                if (_eaters.All(eater => eater.IsEated))
                {
                    _isGameFinished = true;
                    _backingGameUICntrl.SwitchToNextLevelUI();
                }
            }
        }
    }
}