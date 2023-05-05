using System.Collections;
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
                    createBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);

                for (int angle = 8; angle < 360; angle += 15)
                {
                    Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                    createBullet(eye.transform.position, dir);
                }
                yield return new WaitForSeconds(0.3f);
            }

            for(int angle = 0; angle < 1080; angle += 15)
            {
                Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                Vector3 pupulPos = eyeScript.lookAt(eye.transform.position - dir);
                createBullet(pupulPos, dir);
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

        private void createBullet(Vector3 v1, Vector3 v2)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<SimpleArrow>().init(v2);
            o.SetActive(true);
        }
    }
}