/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Eyes;
using Bullet;

namespace Pattern
{
    public class EyePatternB : PatternBase
    {
        void Start()
        {
            base.init();
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(1f);
            setSimpleArrowSpeed(5f);
            eyeScript.openEye();
            yield return new WaitForSeconds(4f);

            StartCoroutine(runHeartBullet());
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 6; i++)
            {
                for (int angle = 0; angle < 360; angle += 15)
                {
                    Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                    createSimpleArrowBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);

                for (int angle = 8; angle < 360; angle += 15)
                {
                    Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                    createSimpleArrowBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);
            }
            updateTriangleList();
            multiplyTriangleSpeed(-2f);

            yield return new WaitForSeconds(3f);
            eyeScript.closeEye();

            yield return new WaitForSeconds(5f);
            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        private IEnumerator runHeartBullet()
        {
            for (int i = 0; i < 34; i += 1)
            {
                createTriangleBullet(new Vector3(0, 0, 0), new Vector3(Mathf.Cos(heartDir[i] * Mathf.Deg2Rad), Mathf.Sin(heartDir[i] * Mathf.Deg2Rad), 0), heartSpeed[i] / 50);
            }
            yield break;
        }
    }
}*/