using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Games.BackingGame
{
    public class Meal : MonoBehaviour
    {
        public int NextDonenesSeconds { get; private set; } = 0;

        [CanBeNull] private MealConfig _mealConfig;
        
        [SerializeField] private Image _image;

        private EDoneness _currentDonenes = 0;

        public bool EqualsMealsConfig(EMeal meal, EDoneness donenes)
        {
            return _mealConfig != null && _mealConfig.MealType == meal && _currentDonenes == donenes;
        }
        
        public void Init(MealConfig mealConfig)
        {
            Donenes raw = mealConfig.Doneness[(int)_currentDonenes];
            if (raw == null)
            {
                return;
            }

            _image.sprite = raw.Sprite;
            _image.color = raw.Tint;

            NextDonenesSeconds = mealConfig.NextDonensSeconds;

            _mealConfig = mealConfig;
        }

        public void ChangeToNextDonenes()
        {
            if (_mealConfig == null)
            {
                return;
            }

            if ((int)_currentDonenes + 1 == _mealConfig.Doneness.Length)
            {
                return;
            }

            _currentDonenes++;

            _image.sprite = _mealConfig.Doneness[(int)_currentDonenes].Sprite;
            _image.color = _mealConfig.Doneness[(int)_currentDonenes].Tint;
        }
    }
}