using System;
using System.Linq;
using UnityEngine;

namespace Games.FarmerGame.Levels
{
    public class ThirdLevel : BaseLevel
    {
        [SerializeField] private WateringCan _wateringCan;
        [SerializeField] private HolesCntrl[] _holesCntrls;

        private void Update()
        {
            if (!IsCompleted)
            {
                IsCompleted = _holesCntrls.All(hole => hole.IsFruitedAll);    
            }
        }

        public override void OnStartLevel()
        {
            _wateringCan.gameObject.SetActive(true);
        }

        public override void OnFinishLevel()
        {
            _wateringCan.gameObject.SetActive(false);
        }
    }
}