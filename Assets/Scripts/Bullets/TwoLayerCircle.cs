using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class TwoLayerCircle : BulletBase
    {
        void Update()
        {
            base.move();
            speed = base.bulletManagerScript.getTwoLayerCircleSpeed();
            if(!base.isObjectInCamera())
            {
                Invoke("destroy", 3f);
            }
        }
    }
}