using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> patternList;

        private List<GameObject> currentPatternList;

        // Start is called before the first frame update
        void Start()
        {
            currentPatternList = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentPatternList.Count == 0)
            {
                int r = Random.Range(0, patternList.Count);
                GameObject p = Instantiate(patternList[r]) as GameObject;
                p.transform.SetParent(transform);
                currentPatternList.Add(p);
            }
        }

        public void removeDestroyedPattern()
        {
            currentPatternList.RemoveAt(0);
        }
    }
}