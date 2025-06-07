using UnityEngine;

namespace Games.FarmerGame.Levels
{
    public abstract class BaseLevel : MonoBehaviour
    {
        public bool IsCompleted { get; protected set; } = false;

        public abstract void OnStartLevel();
        public abstract void OnFinishLevel();
    }
}