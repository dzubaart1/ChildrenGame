using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public enum ESound
    {
        Button,
        BeginDrag,
        FailDrag,
        Success
    }
    
    
    public class SoundManager : MonoBehaviour
    {
        [Serializable]
        private class SoundConfig
        {
            public ESound Type;
            public AudioClip Clip;
        }
        
        [Header("Refs")]
        [SerializeField] private AudioSource _backgroundSoundSource;
        [SerializeField] private AudioSource _additionalSoundSource;
     
        [Space]
        [Header("Configs")]
        [Range(0f, 10f)] [SerializeField] private float _backgroundSoundVolume;
        [Range(0f, 10f)] [SerializeField] private float _additionalSoundVolume;

        [SerializeField] private List<SoundConfig> _soundConfigs;
        
        [CanBeNull] public static SoundManager Instance { get; private set; }

        public bool IsMute { get; private set; } = false;
    
        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        
            DontDestroyOnLoad(gameObject);

            _backgroundSoundSource.volume = _backgroundSoundVolume;
            _additionalSoundSource.volume = _additionalSoundVolume;
        }

        public void PlayAdditionalSound(ESound sound)
        {
            SoundConfig soundConfig = _soundConfigs.FirstOrDefault(config => config.Type == sound);
            if (soundConfig == null)
            {
                return;
            }

            _additionalSoundSource.clip = soundConfig.Clip;
            _additionalSoundSource.Play();
        }

        public void ToggleMute()
        {
            IsMute = !IsMute;
            _backgroundSoundSource.gameObject.SetActive(IsMute);
            _additionalSoundSource.gameObject.SetActive(IsMute);
        }
    }
}