using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools
{
    public class LoadSceneAtStart : MonoBehaviour
    {
        [SerializeField] private string _defaultScene;
        
        private void Start()
        {
            SceneManager.LoadScene(_defaultScene);
        }
    }
}