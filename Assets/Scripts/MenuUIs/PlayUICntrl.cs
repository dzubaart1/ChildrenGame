using UnityEngine;
using UnityEngine.UI;

public class PlayUICntrl : MenuUIBase
{
    [SerializeField] private Button _playButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        if (MenuCntrl == null)
        {
            return;
        }
        
        MenuCntrl.SwitchToSettingsUI();
    }
}
