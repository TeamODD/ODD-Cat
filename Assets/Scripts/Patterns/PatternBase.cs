using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternBase : MonoBehaviour
    {
        [SerializeField] public GameObject RightArrow;

        private float speed;

        public void setSpeed(float s)
        {
            speed = s;
        }

        public float getSpeed()
        {
            return speed;
        }
    }
}