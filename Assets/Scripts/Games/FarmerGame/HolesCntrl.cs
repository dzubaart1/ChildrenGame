using System;
using System.Linq;
using UnityEngine;

namespace Games.FarmerGame
{
    public class HolesCntrl : MonoBehaviour
    {
        [SerializeField] private Hole[] _holes;

        public bool IsSeededAll
        {
            get
            {
                return _holes.All(hole => hole.IsSeeded);
            }
        }

        public bool IsFruitedAll
        {
            get
            {
                return _holes.All(hole => hole.IsFruited);
            }
        }

        public bool IsCaredAll
        {
            get
            {
                return _holes.All(hole => hole.IsCared);
            }
        }
        
        private void Start()
        {
            foreach (var hole in _holes)
            {
                hole.HideAll();
            }
        }

        public void ShowAllHolesBackground()
        {
            foreach (var hole in _holes)
            {
                hole.ShowBackground();
            }
        }
    }
}