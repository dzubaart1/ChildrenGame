using Games.BackingGame;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Meal meal = other.GetComponentInChildren<Meal>();
        if (meal == null)
        {
            return;
        }
        
        meal.gameObject.SetActive(false);
    }
}
