using System;
using System.Linq;
using UnityEngine;

namespace Games.FarmerGame.Levels
{
    public class FourthLevel : BaseLevel
    {
        [SerializeField] private CarCntrl[] _carCntrls;
        [SerializeField] private HolesCntrl[] _holesCntrls;

        private void Update()
        {
            if (!IsCompleted)
            {
                IsCompleted = _holesCntrls.All(holesCntrl => holesCntrl.IsCaredAll);
            }
        }

        public override void OnStartLevel()
        {
            foreach (var car in _carCntrls)
            {
                car.gameObject.SetActive(true);
            }
        }

        public override void OnFinishLevel()
        {
            foreach (var car in _carCntrls)
            {
                car.gameObject.SetActive(false);
            }
        }
    }
}