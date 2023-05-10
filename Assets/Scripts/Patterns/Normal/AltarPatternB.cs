using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class AltarPatternB : PatternBase
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
            yield return new WaitForSeconds(4f);



            for (int i = 0; i < 3; i++)
            {
                createHeart();
                yield return new WaitForSeconds(0.5f);

                createCircle();
                yield return new WaitForSeconds(0.5f);

                createCircle();
                yield return new WaitForSeconds(0.5f);
            }


            yield return new WaitForSeconds(2f);
            altarScript.setDisable();
            yield return new WaitForSeconds(3f);

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

        private void createHeart()
        {
            for(int i=0; i<34; i++)
            {
                float x = Mathf.Cos(bulletManagerScript.heartDir[i] * Mathf.Deg2Rad);
                float y = Mathf.Sin(bulletManagerScript.heartDir[i] * Mathf.Deg2Rad);
                bulletManagerScript.createHeartBullet(new Vector3(0, 0, 0), new Vector3(x, y, 0), bulletManagerScript.heartSpeed[i] * 0.05f);
            }
        }
    }
}