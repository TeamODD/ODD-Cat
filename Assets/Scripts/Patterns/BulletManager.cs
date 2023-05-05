using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float simpleArrowSpeed;
    private float twoLayerCircleSpeed;

    public void setSimpleArrowSpeed(float speed)
    {
        simpleArrowSpeed = speed;
    }

    public float getSimpleArrowSpeed()
    {
        return simpleArrowSpeed;
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
