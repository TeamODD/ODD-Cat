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
            setSpeed(10f);
            StartCoroutine(runPattern());
        }

        private IEnumerator runPattern()
        {
            yield return new WaitForSeconds(0.5f);
            float delay = 1f;
            
            while(0 < delay)
            {
                createBooletFromOutside();
                delay -= 0.02f;
                yield return new WaitForSeconds(delay);
            }


            yield break;
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

        private void createBooletFromOutside()
        {
            GameObject o = Instantiate(RightArrow) as GameObject;
            o.transform.SetParent(gameObject.transform);
            o.transform.position = Camera.main.ViewportToWorldPoint(getRandomPosFromCamera());
            o.GetComponent<RightArrow>().setUnit(player.transform.position);
            o.GetComponent<RightArrow>().setSpeed(getSpeed());
            o.SetActive(true);
        }
    }
}