using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bullet;
using static Icons.Icon;

namespace Pattern
{ 
    public class NormalPatternA : PatternBase
    {
        void Start()
        {
            base.init();
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(1.5f);
            setSimpleArrowSpeed(5f);
            float x, y;

            // first cycle

            for (x = 0.5f, y = 0f; 0 <= x; x -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 1f; x <= 1; x += 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 0f; 0.5f <= x; x -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.1f);
            }

            // first cycle end

            setSimpleArrowSpeed(0);
            uiManagerScript.show(IconType.pause);
            yield return new WaitForSeconds(1.5f);

            setSimpleArrowSpeed(5f);
            uiManagerScript.show(IconType.play);
            yield return new WaitForSeconds(3f);
            uiManagerScript.hide();

            // second cycle

            for (x = 0.5f, y = 0f; 0 <= x; x -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 1f; x <= 1; x += 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 1f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 1f, y = 0f; 0f <= x; x -= 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                createBullet(v);
                yield return new WaitForSeconds(0.05f);
            }

            // second cycle end

            setSimpleArrowSpeed(0);
            uiManagerScript.show(IconType.pause);
            yield return new WaitForSeconds(3f);

            setSimpleArrowSpeed(-5f);
            uiManagerScript.show(IconType.rewind);
            yield return new WaitForSeconds(3f);

            setSimpleArrowSpeed(5f);
            uiManagerScript.show(IconType.play);
            yield return new WaitForSeconds(3f);
            uiManagerScript.hide();

            yield return new WaitForSeconds(5f);

            GetComponentInParent<PatternManager>().removeDestroyedPattern();

            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        private void createBullet(Vector3 v)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v;
            o.GetComponent<SimpleArrow>().init(new Vector3(0, 0, 0));
            o.SetActive(true);
        }
    }
}