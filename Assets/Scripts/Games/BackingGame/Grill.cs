using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;

namespace Games.BackingGame
{
    public class Grill : MonoBehaviour
    {
        private class MealInGrill
        {
            public Meal Meal;
            public float DonenesEndTime;
        }
        
        private List<MealInGrill> _mealsInGrill = new List<MealInGrill>();

        private void Update()
        {
            foreach (var mealInGrill in _mealsInGrill)
            {
                if (Time.time >= mealInGrill.DonenesEndTime)
                {
                    mealInGrill.DonenesEndTime = Time.time + mealInGrill.Meal.NextDonenesSeconds;
                    mealInGrill.Meal.ChangeToNextDonenes();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Meal meal = other.GetComponentInChildren<Meal>();
            if (meal == null)
            {
                return;
            }

            MealInGrill target = _mealsInGrill.FirstOrDefault(el => el.Meal == meal);
            _mealsInGrill.Remove(target);
        }

        public void AddMealToGrill(Meal meal)
        {
            DraggableUI draggableUI = meal.GetComponentInChildren<DraggableUI>();
            if (draggableUI == null)
            {
                return;
            }

            draggableUI.enabled = false;
            draggableUI.enabled = true;
            
            _mealsInGrill.Add(new MealInGrill()
            {
                Meal = meal,
                DonenesEndTime = meal.NextDonenesSeconds + Time.time
            });
        }
    }
}