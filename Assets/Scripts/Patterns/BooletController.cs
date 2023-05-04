using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooletController : MonoBehaviour
{
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
