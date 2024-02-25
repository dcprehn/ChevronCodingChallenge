using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aoiti.Techs
{
    public class GameInitializer : MonoBehaviour
    {
        public Techtree techtree; // Assign your Techtree asset in the Inspector

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Add any other initialization logic here
            techtree.ResetTechtree();
        }
    }
}
