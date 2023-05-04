using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Boolet;
using static Icons.Icon;

namespace Pattern
{
    public class EasyPatternB : PatternBase
    {
        void Start()
        {
            base.init();
            GetComponent<BooletController>().setSimpleArrowSpeed(6f);
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(0.5f);
            float x, y;

            // first cycle

            for (x = 0.5f, y = 0f; 0 <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 0f, y = 1f; x <= 1; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            for (x = 1f, y = 0f; 0.5f <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.1f);
            }

            // first cycle end

            // second cycle

            for (x = 0.5f, y = 0f; 0 <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 1f; x <= 1; x += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 1f, y = 1f; 0f <= y; y -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 1f, y = 0f; 0f <= x; x -= 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            for (x = 0f, y = 0f; y <= 1f; y += 0.1f)
            {
                Vector3 v = new Vector3(x, y, 10);
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(v));
                yield return new WaitForSeconds(0.05f);
            }

            GetComponent<BooletController>().setSimpleArrowSpeed(0f);
            getUIManager().GetComponent<UIManager>().show(IconType.pause);

            yield return new WaitForSeconds(2f);
            GetComponent<BooletController>().setSimpleArrowSpeed(-5f);
            getUIManager().GetComponent<UIManager>().show(IconType.rewind);

            yield return new WaitForSeconds(5f);
            GetComponent<BooletController>().setSimpleArrowSpeed(5f);
            getUIManager().GetComponent<UIManager>().show(IconType.play);

            yield return new WaitForSeconds(1.5f);
            getUIManager().GetComponent<UIManager>().hide();


            // second cycle end

            yield return new WaitForSeconds(60f);
            Destroy(gameObject);
        }

        private void createBooletFromOutside(Vector3 v)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(gameObject.transform);
            o.transform.position = v;
            o.GetComponent<SimpleArrow>().init(new Vector3(0, 0, 0));
            o.SetActive(true);
        }
    }
}