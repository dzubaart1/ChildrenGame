using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Games.BackingGame
{
    [Serializable]
    public class Donenes
    {
        public Sprite Sprite;
        public Color Tint;
    }
    
    [CreateAssetMenu(fileName = "MealConfig", menuName = "BackingGame/MealConfig", order = 1)]
    public class MealConfig : ScriptableObject
    {
        public int NextDonensSeconds;
        public EMeal MealType;
        public Donenes[] Doneness;
    }
}