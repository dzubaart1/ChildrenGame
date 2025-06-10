using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Games.FarmerGame.Levels
{
    public class FirstLevel : BaseLevel
    {
        [SerializeField] private TractorCntrl[] _tractorCntrls;

        private void Update()
        {
            if (!IsCompleted)
            {
                IsCompleted = _tractorCntrls.All(tractor => tractor.IsCompleted);
            }
        }

        public override void OnStartLevel()
        {
            foreach (var tractor in _tractorCntrls)
            {
                tractor.gameObject.SetActive(true);
            }
        }

        public override void OnFinishLevel()
        {
            foreach (var tractor in _tractorCntrls)
            {
                tractor.gameObject.SetActive(false);
                tractor.FillProgressBar();
            }
        }
    }
}