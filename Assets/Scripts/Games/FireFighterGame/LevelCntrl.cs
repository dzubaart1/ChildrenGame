using UnityEngine;

namespace Games.FireFighterGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private FireFighterGameUICntrl _fireFighterGameUICntrl;
        [SerializeField] private PlaceHolder _placeHolder;
        
        private bool _isGameFinished = false;
        
        private void Update()
        {
            if (!_isGameFinished)
            {
                if (_placeHolder.IsActivated)
                {
                    _isGameFinished = true;
                    _fireFighterGameUICntrl.SwitchToNextLevelUI();
                }
            }
        }
    }
}