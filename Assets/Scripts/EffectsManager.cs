using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public class EffectsManager : MonoBehaviour
    {
        [SerializeField] private Canvas _congratualtionsCanvas;
        [SerializeField] private Animator _congratulationsAnimator;
        
        [CanBeNull] public static EffectsManager Instance { get; private set; }
    
        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        
            DontDestroyOnLoad(gameObject);
        }

        public void StartCongratulations()
        {
            StartCoroutine(OnStartCongratulations());
        }

        private IEnumerator OnStartCongratulations()
        {
            _congratualtionsCanvas.gameObject.SetActive(true);
            _congratulationsAnimator.Play("StartAnim");
            yield return new WaitForSeconds(2f);
            _congratualtionsCanvas.gameObject.SetActive(false);
        }
    }
}