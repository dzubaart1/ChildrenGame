using System;
using UnityEngine;
using UnityEngine.UI;

namespace Games.FarmerGame
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Hole : MonoBehaviour
    {
        public bool IsSeeded { get; private set; } = false;
        public bool IsSprouted { get; private set; } = false;
        public bool IsFruited { get; private set; } = false;
        public bool IsCared { get; private set; }
        
        [SerializeField] private Image _background;
        [SerializeField] private Image _seed;
        [SerializeField] private Image _sprout;
        [SerializeField] private Image _fruit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Seeds seeds = other.GetComponentInChildren<Seeds>();
            if (seeds != null && !IsSeeded)
            {
                IsSeeded = true;
                _seed.gameObject.SetActive(true);
            }

            WateringCan wateringCan = other.GetComponentInChildren<WateringCan>();
            if (wateringCan != null && !IsSprouted)
            {
                IsSprouted = true;
                _sprout.gameObject.SetActive(true);
                _seed.gameObject.SetActive(false);
            }

            if (wateringCan != null && !IsFruited)
            {
                IsFruited = true;
                _fruit.gameObject.SetActive(true);
                _sprout.gameObject.SetActive(false);
            }

            CarCntrl carCntrl = other.GetComponentInChildren<CarCntrl>();
            if (carCntrl != null && !IsCared)
            {
                IsCared = true;
                _fruit.gameObject.SetActive(false);
            }
        }

        public void HideAll()
        {
            _background.gameObject.SetActive(false);
            _seed.gameObject.SetActive(false);
            _sprout.gameObject.SetActive(false);
            _fruit.gameObject.SetActive(false);
        }
        
        public void ShowBackground()
        {
            _background.gameObject.SetActive(true);
        }
    }
}