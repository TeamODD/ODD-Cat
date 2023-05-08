using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bullet;

namespace Pattern
{
    public class EasyPatternC : PatternBase
    {
        // Start is called before the first frame update
        void Start()
        {
            base.init();
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(1f);
            setMushroomYSpeed(5f);
            float x, y;

            x = 0; y = 1;
            for (int angle = 270; angle <= 360; angle += 10) 
            {
                Vector3 v1 = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                Vector3 v2 = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                createMushroomYBullet(v1, v1 + v2);
            }
            yield return new WaitForSeconds(0.3f);

            x = 1; y = 0;
            for (int angle = 90; angle <= 180; angle += 10)
            {
                Vector3 v1 = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                Vector3 v2 = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                createMushroomYBullet(v1, v1 + v2);
            }
            yield return new WaitForSeconds(2f);

            x = 0; y = 0;
            for (int angle = 0; angle <= 90; angle += 10)
            {
                Vector3 v1 = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                Vector3 v2 = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                createMushroomYBullet(v1, v1 + v2);
            }
            yield return new WaitForSeconds(0.3f);

            x = 1; y = 1;
            for (int angle = 180; angle <= 270; angle += 10)
            {
                Vector3 v1 = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                Vector3 v2 = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                createMushroomYBullet(v1, v1 + v2);
            }

            yield return new WaitForSeconds(5f);

            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }
    }
}