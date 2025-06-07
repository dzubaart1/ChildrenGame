using System;
using Games.BackingGame;
using UnityEngine;

public class BackingGameUICntrl : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private LevelCntrl[] _levelCntrls;
        
    private int _currentUIID = 0;
    
    private void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        
        foreach (var levelCntrl in _levelCntrls)
        {
            levelCntrl.gameObject.SetActive(false);
        }
        
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
