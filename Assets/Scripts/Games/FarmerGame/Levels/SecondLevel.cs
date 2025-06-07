using System;
using System.Linq;
using UnityEngine;

namespace Games.FarmerGame.Levels
{
    public class SecondLevel : BaseLevel
    {
        [SerializeField] private Seeds _seeds;
        [SerializeField] private HolesCntrl[] _holesCntrls;

        private void Update()
        {
            if (!IsCompleted)
            {
                IsCompleted = _holesCntrls.All(hole => hole.IsSeededAll);
            }
        }

        public override void OnStartLevel()
        {
            _seeds.gameObject.SetActive(true);
            
            foreach (var holesCntrl in _holesCntrls)
            {
                holesCntrl.ShowAllHolesBackground();
            }
        }

        public override void OnFinishLevel()
        {
            _seeds.gameObject.SetActive(false);
        }
    }
}