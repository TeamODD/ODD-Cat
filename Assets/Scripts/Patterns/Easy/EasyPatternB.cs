using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Boolet;

namespace Pattern
{
    public class EasyPatternB : PatternBase
    {
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            setSimpleArrowSpeed(10f);
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(0.5f);
            float x, y;

            // first cycle

            for (x = 0.5f, y = 0f; x <= 1f; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 1f; 0f <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 0f; x <= 0.5f; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            // first cycle

            // second cycle

            for (x = 0.5f, y = 0f; x <= 1f; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 1f; 0f <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 0f; x <= 0.5f; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 0);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            // second cycle

            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }

        private void createBooletFromOutside(Vector3 v)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(gameObject.transform);
            o.transform.position = v;
            o.GetComponent<SimpleArrow>().setUnit(new Vector3(0, 0, 0));
            o.GetComponent<SimpleArrow>().setSpeed(getSimpleArrowSpeed());
            o.SetActive(true);
        }
    }
}