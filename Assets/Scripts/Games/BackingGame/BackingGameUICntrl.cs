using System.Collections;
using System.Linq;
using DefaultNamespace;
using Games.BackingGame;
using UnityEngine;

public class BackingGameUICntrl : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private LevelCntrl[] _levelCntrls;
        
    private int _currentUIID = 0;
    private bool _isGameFinished = false;
    
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

    private void Update()
    {
        if (!_isGameFinished)
        {
            if (_levelCntrls.All(level => level.IsLevelCompleted))
            {
                _isGameFinished = true;
                StartCoroutine(OnGameFinished());
            }
        }
    }

    public void SwitchToNextLevelUI()
    {
        _levelCntrls[_currentUIID].gameObject.SetActive(false);

        if (_currentUIID + 1 < _levelCntrls.Length)
        {
            _levelCntrls[++_currentUIID].gameObject.SetActive(true);    
        }
    }

    private IEnumerator OnGameFinished()
    {
        EffectsManager effectsManager = EffectsManager.Instance;
        if (effectsManager == null)
        {
            yield break;
        }
        
        GameManager gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            yield break;
        }
        
        SoundManager soundManager = SoundManager.Instance;
        if (soundManager == null)
        {
            yield break;
        }
        
        effectsManager.StartCongratulations();
        soundManager.PlayAdditionalSound(ESound.Success);
        yield return new WaitForSeconds(1f);
        
        gameManager.StartMenuScene();
    }
}
