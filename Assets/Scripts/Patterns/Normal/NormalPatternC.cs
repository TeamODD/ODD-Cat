using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Icons.Icon;

namespace Pattern
{
    public class NormalPatternC : PatternBase
    {
        void Start()
        {
            base.init();
            bulletManagerScript.setMushroomRSpeed(6f);
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(0.5f);
            float delay = 0.7f;

            StartCoroutine(runRewind());

            while (0 < delay)
            {
                bulletManagerScript.createMushroomRBullet(Camera.main.ViewportToWorldPoint(getRandomPosFromCamera()), player.transform.position);
                delay -= 0.02f;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(5f);

            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        private Vector3 getRandomPosFromCamera()
        {
            Vector3 v;
            float[] arr = new float[2];

            arr[0] = Random.Range(0, 2);
            arr[1] = Random.Range(0f, 1f);

            int r = Random.Range(0, 2);
            if (r == 0)
            {
                v = new Vector3(arr[0], arr[1], 10);
            }
            else
            {
                v = new Vector3(arr[1], arr[0], 10);
            }
            return v;
        }

        private IEnumerator runRewind()
        {
            yield return new WaitForSeconds(7f);

            bulletManagerScript.setMushroomRSpeed(-6f);
            uiManagerScript.show(IconType.rewind);
            yield return new WaitForSeconds(1.5f);

            bulletManagerScript.setMushroomRSpeed(6f);
            uiManagerScript.show(IconType.play);
            yield return new WaitForSeconds(3f);
            uiManagerScript.hide();
        }
    }
}