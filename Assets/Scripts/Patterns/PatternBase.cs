using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternBase : MonoBehaviour
    {
        [SerializeField] public GameObject SimpleArrow;
        private GameObject player;
        private GameObject uiManager;
        
        public void init()
        {
            player = GameObject.FindWithTag("Player");
            uiManager = GameObject.FindWithTag("UIManager");
        }

        public GameObject getPlayer()
        {
            return player;
        }

        public GameObject getUIManager()
        {
            return uiManager;
        }


    }
}