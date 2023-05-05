using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Eyes;

namespace Pattern
{
    public class PatternBase : MonoBehaviour
    {
        [SerializeField] public GameObject SimpleArrow;
        [SerializeField] public GameObject TwoLayerCircle;

        public GameObject player;
        public GameObject eye;
        public GameObject uiManager;
        public GameObject bulletManager;

        public Eye eyeScript;
        public Player playerScript;
        public UIManager uiManagerScript;
        public BulletManager bulletManagerScript;
        
        public void init()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            eye = GameObject.FindGameObjectWithTag("Eye");
            uiManager = GameObject.FindGameObjectWithTag("UIManager");
            bulletManager = GameObject.FindGameObjectWithTag("BulletManager");

            eyeScript = eye.GetComponent<Eye>();
            playerScript = player.GetComponent<Player>();
            uiManagerScript = uiManager.GetComponent<UIManager>();
            bulletManagerScript = bulletManager.GetComponent<BulletManager>();
        }

        public void setSimpleArrowSpeed(float speed)
        {
            bulletManagerScript.setSimpleArrowSpeed(speed);
        }

        public void setTwoLayerCircleSpeed(float speed)
        {
            bulletManagerScript.setTwoLayerCircleSpeed(speed);
        }
    }
}