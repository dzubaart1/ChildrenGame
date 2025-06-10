using JetBrains.Annotations;
using UnityEngine;

public class MenuCntrl : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private RectTransform _settingsUI;
    [SerializeField] private RectTransform _chooseGameUI;
    
    [Space]
    [Header("Others")]
    [SerializeField] private RectTransform _defaultUI;
    
    [CanBeNull] private RectTransform _currentUI;
    
    private void Start()
    {
        _settingsUI.gameObject.SetActive(false);
        _chooseGameUI.gameObject.SetActive(false);
        
        _defaultUI.gameObject.SetActive(true);
        _currentUI = _defaultUI;
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
