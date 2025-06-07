using JetBrains.Annotations;
using UnityEngine;

namespace Games.FireFighterGame
{
    public class FireFighterGameUICntrl : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private LevelCntrl[] _levelCntrls;
        
        private int _currentUIID;

        private void Start()
        {
            foreach (var levelCntrl in _levelCntrls)
            {
                levelCntrl.gameObject.SetActive(false);
            }

            _currentUIID = 0;
            _levelCntrls[_currentUIID].gameObject.SetActive(true);
        }
        
        public void SwitchToNextLevelUI()
        {
            _levelCntrls[_currentUIID].gameObject.SetActive(false);

            if (_currentUIID + 1 < _levelCntrls.Length)
            {
                _levelCntrls[++_currentUIID].gameObject.SetActive(true);    
            }
        }
    }
}