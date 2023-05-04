using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class SimpleArrow : BulletBase
    {
        void Update()
        {
            base.move();
            speed = base.bulletManagerScript.getSimpleArrowSpeed();
            if (!base.isObjectInCamera())
            {
                Invoke("destroy", 3f);
            }
        }
    }
}