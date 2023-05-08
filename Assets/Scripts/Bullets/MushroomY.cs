using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class MushroomY : BulletBase
    {
        void Update()
        {
            base.move();
            speed = base.bulletManagerScript.getMushroomYSpeed();
            if (!base.isObjectInCamera())
            {
                Invoke("destroy", 3f);
            }
        }
    }
}