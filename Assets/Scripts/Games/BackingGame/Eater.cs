using System;
using UnityEngine;

namespace Games.BackingGame
{
    public class Eater : MonoBehaviour
    {
        [Serializable]
        private class EaterMealConfig
        {
            public EMeal Meal;
            public EDoneness Donenes;
        }

        public bool IsEated { get; private set; } = false;

        [SerializeField] private EaterMealConfig _mealConfig;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Meal meal = other.GetComponentInChildren<Meal>();
            if (meal == null)
            {
                return;
            }

            if (meal.EqualsMealsConfig(_mealConfig.Meal, _mealConfig.Donenes))
            {
                OnMealEntered(meal);
            }
        }

        private void OnMealEntered(Meal meal)
        {
            IsEated = true;
            meal.gameObject.SetActive(false);
        }
    }
}