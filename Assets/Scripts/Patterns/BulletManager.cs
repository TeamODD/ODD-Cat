using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float SimpleArrowSpeed;
    private float twoLayerCircleSpeed;

    public void setSimpleArrowSpeed(float speed)
    {
        SimpleArrowSpeed = speed;
    }

    public float getSimpleArrowSpeed()
    {
        return SimpleArrowSpeed;
    }

    public void setTwoLayerCircleSpeed(float speed)
    {
        twoLayerCircleSpeed = speed;
    }

    public float getTwoLayerCircleSpeed()
    {
        return twoLayerCircleSpeed;
    }
}
