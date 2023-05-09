using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> easyPatternList;
        [SerializeField] List<GameObject> normalPatternList;
        [SerializeField] List<GameObject> allPatternList;

        private List<GameObject> currentPatternList;

        // Start is called before the first frame update
        void Start()
        {
            currentPatternList = new List<GameObject>();
            /*StartCoroutine(betaPattern());*/
            StartCoroutine(runPattern());
        }

        // Update is called once per frame
        /*void Update()
        {
            if (currentPatternList.Count == 0)
            {
                int r = Random.Range(0, normalPatternList.Count);
                GameObject p = Instantiate(easyPatternList[i]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);
            }
        }*/

        /*IEnumerator betaPattern()
        {
            yield return new WaitForSeconds(3f);

            *//*for (int i = 0; i < easyPatternList.Count; i++)
            {
                GameObject p = Instantiate(easyPatternList[i]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }*//*


            for (int i = 0; i < normalPatternList.Count; i++)
            {
                GameObject p = Instantiate(normalPatternList[i]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }
        }*/

        IEnumerator runPattern()
        {
            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, easyPatternList.Count);
                GameObject p = Instantiate(easyPatternList[r]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                int r = Random.Range(0, easyPatternList.Count);
                GameObject p = Instantiate(normalPatternList[r]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }

            while (true)
            {
                int r = Random.Range(0, allPatternList.Count);
                GameObject p = Instantiate(allPatternList[r]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        public void removeDestroyedPattern()
        {
            currentPatternList.RemoveAt(0);
        }
    }
}