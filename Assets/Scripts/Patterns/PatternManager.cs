using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> easyPatternList;
        [SerializeField] List<GameObject> normalPatternList;

        private List<GameObject> currentPatternList;

        // Start is called before the first frame update
        void Start()
        {
            currentPatternList = new List<GameObject>();
            StartCoroutine(betaPattern());
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

        IEnumerator betaPattern()
        {
            for (int i = 0; i < easyPatternList.Count; i++)
            {
                GameObject p = Instantiate(easyPatternList[i]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);

                while (currentPatternList.Count != 0)
                {
                    yield return new WaitForSeconds(1f);
                }
            }


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
        }

        public void removeDestroyedPattern()
        {
            currentPatternList.RemoveAt(0);
        }
    }
}