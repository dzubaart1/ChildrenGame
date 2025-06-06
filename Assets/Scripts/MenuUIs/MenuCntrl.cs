using JetBrains.Annotations;
using UnityEngine;

public class MenuCntrl : MonoBehaviour
{
    [SerializeField] private MenuUIBase _defaultUI;
    
    [SerializeField] private MenuUIBase _playUI;
    [SerializeField] private MenuUIBase _settingsUI;
    [SerializeField] private MenuUIBase _chooseGameUI;

    [CanBeNull] private MenuUIBase _currentUI;
    
    private void Awake()
    {
        _playUI.Init(this);
        _settingsUI.Init(this);
        _chooseGameUI.Init(this);
    }

    private void Start()
    {
        _playUI.gameObject.SetActive(false);
        _settingsUI.gameObject.SetActive(false);
        _chooseGameUI.gameObject.SetActive(false);
        
        _defaultUI.gameObject.SetActive(true);
        _currentUI = _defaultUI;
    }

    public void SwitchToSettingsUI()
    {
        if (_currentUI != null)
        {
            _currentUI.gameObject.SetActive(false);
        }
        
        _settingsUI.gameObject.SetActive(true);
    }

    public void SwitchToChooseGameUI()
    {
        if (_currentUI != null)
        {
            _currentUI.gameObject.SetActive(false);
        }
        
        _chooseGameUI.gameObject.SetActive(true);
    }
}
