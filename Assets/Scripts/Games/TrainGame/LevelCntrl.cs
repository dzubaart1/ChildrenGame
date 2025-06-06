using System.Linq;
using UnityEngine;

namespace Games.TrainGame
{
    public class LevelCntrl : MonoBehaviour
    {
        [SerializeField] private TrainGameUICntrl _trainGameUICntrl;
        [SerializeField] private Socket[] _sockets;

        private bool _isGameFinished = false;
        
        private void Update()
        {
            if (!_isGameFinished)
            {
                if (_sockets.All(socket => socket.IsActivated))
                {
                    _isGameFinished = true;
                    _trainGameUICntrl.SwitchToChooseLevelUI();
                }
            }
        }
    }
}