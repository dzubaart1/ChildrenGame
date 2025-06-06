using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _trainGameSceneName;
    [SerializeField] private string _fireFighterGameSceneName;
    [SerializeField] private string _backingGameSceneName;
    [SerializeField] private string _fishingGameSceneName;
    [SerializeField] private string _iceCreamGameSceneName;
    [SerializeField] private string _farmerGameSceneName;
    
    [CanBeNull] public static GameManager Instance { get; private set; }
    
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);    
    }

    public void StartTrainGameScene()
    {
        SceneManager.LoadScene(_trainGameSceneName);
    }

    public void StartFireFighterGameScene()
    {
        SceneManager.LoadScene(_fireFighterGameSceneName);
    }

    public void StartBackingGameScene()
    {
        SceneManager.LoadScene(_backingGameSceneName);
    }

    public void StartFishingGameScene()
    {
        SceneManager.LoadScene(_fishingGameSceneName);
    }

    public void StartIceCreamGameScene()
    {
        SceneManager.LoadScene(_iceCreamGameSceneName);
    }

    public void StartFarmerGameScene()
    {
        SceneManager.LoadScene(_farmerGameSceneName);
    }
}
