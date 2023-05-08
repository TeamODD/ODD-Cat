/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Eyes;
using Bullet;

namespace Pattern
{
    public class EyePatternA : PatternBase
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

            for (int i = 0; i < 2; i++)
            {
                for (int angle = 0; angle < 360; angle += 15)
                {
                    Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                    base.createSimpleArrowBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);

                for (int angle = 8; angle < 360; angle += 15)
                {
                    Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                    base.createSimpleArrowBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);
            }

            for(int angle = 0; angle < 1440; angle += 15)
            {
                Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                Vector3 pupulPos = eyeScript.lookAt(eye.transform.position - dir);
                createSimpleArrowBullet(pupulPos, dir);
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(1f);
            eyeScript.lookAtCenter();

            yield return new WaitForSeconds(1f);
            eyeScript.closeEye();

            yield return new WaitForSeconds(5f);
            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }
    }
}*/