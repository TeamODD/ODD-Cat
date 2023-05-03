using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] GameObject PatternContainer;
        [SerializeField] GameObject EasyPatternA;
        // Start is called before the first frame update
        void Start()
        {
            GameObject o = Instantiate(EasyPatternA) as GameObject;
            o.transform.SetParent(PatternContainer.transform);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}