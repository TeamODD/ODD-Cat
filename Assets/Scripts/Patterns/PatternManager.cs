using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] GameObject PatternContainer;
        [SerializeField] List<GameObject> patternList;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(run());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator run()
        {
            GameObject p = Instantiate(patternList[1]) as GameObject;
            p.transform.SetParent(PatternContainer.transform);
            yield break;
        }
    }
}