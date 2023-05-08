using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternBase : MonoBehaviour
    {
        [SerializeField] public GameObject SimpleArrow;

        private float SimpleArrowSpeed;

        public void setSimpleArrowSpeed(float s)
        {
            SimpleArrowSpeed = s;
        }

        public float getSimpleArrowSpeed()
        {
            return SimpleArrowSpeed;
        }
    }
}