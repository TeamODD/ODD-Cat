using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float simpleArrowSpeed;
    private float twoLayerCircleSpeed;
    private float mushroomYSpeed;
    private float mushroomRSpeed;

    public void setSimpleArrowSpeed(float speed)
    {
        simpleArrowSpeed = speed;
    }

    public float getSimpleArrowSpeed()
    {
        return simpleArrowSpeed;
    }
    public void setMushroomYSpeed(float speed)
    {
        mushroomYSpeed = speed;
    }

    public float getMushroomYSpeed()
    {
        return mushroomYSpeed;
    }

    public void setMushroomRSpeed(float speed)
    {
        mushroomRSpeed = speed;
    }

    public float getMushroomRSpeed()
    {
        return mushroomRSpeed;
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
