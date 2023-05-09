using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class MushroomR : BulletBase
    {
        void Update()
        {
            base.move();
            speed = base.bulletManagerScript.getMushroomRSpeed();
            if (!base.isObjectInCamera())
            {
                Invoke("destroy", 3f);
            }
        }
    }
}