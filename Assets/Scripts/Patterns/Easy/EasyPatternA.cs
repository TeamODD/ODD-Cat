using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Boolet;

namespace Pattern
{
    public class EasyPatternA : PatternBase
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
            float delay = 1f;
            
            while(0 < delay)
            {
                createBooletFromOutside(Camera.main.ViewportToWorldPoint(getRandomPosFromCamera()));
                delay -= 0.02f;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }

        private Vector3 getRandomPosFromCamera()
        {
            Vector3 v;
            float[] arr = new float[2];

            arr[0] = Random.Range(0, 2);
            arr[1] = Random.Range(0f, 1f);

            int r = Random.Range(0, 2);
            if(r == 0)
            {
                v = new Vector3(arr[0], arr[1], 0);
            }
            else
            {
                v = new Vector3(arr[1], arr[0], 0);
            }
            return v;
        }

        private void createBooletFromOutside(Vector3 v)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(gameObject.transform);
            o.transform.position = v;
            o.GetComponent<SimpleArrow>().setUnit(player.transform.position);
            o.GetComponent<SimpleArrow>().setSpeed(getSimpleArrowSpeed());
            o.SetActive(true);
        }
    }
}