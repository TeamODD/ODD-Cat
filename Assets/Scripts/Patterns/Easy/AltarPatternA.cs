using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bullet;

namespace Pattern
{
    public class AltarPatternA : PatternBase
    {
        void Start()
        {
            base.init();
            bulletManagerScript.setMushroomYSpeed(5f);
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(0.5f);

            altarScript.setEnable();
            yield return new WaitForSeconds(5f);

            for (int i = 0; i < 1440; i += 15)  
            {
                if (i % 360 == 60) createCircle();
                bulletManagerScript.createMushroomYBullet(new Vector3(0, 0, 0), new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0));
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(3f);
            altarScript.setDisable();
            yield return new WaitForSeconds(5f);

            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        private void createCircle()
        {
            for (int i = 0; i < 360; i += 15)
            {
                bulletManagerScript.createMushroomYBullet(new Vector3(0, 0, 0), new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0));
            }
        }
    }
}