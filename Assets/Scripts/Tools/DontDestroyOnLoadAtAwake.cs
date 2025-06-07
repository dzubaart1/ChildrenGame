using UnityEngine;

namespace Tools
{
    public class DontDestroyOnLoadAtAwake : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}