using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eyes
{
    public class Eye : MonoBehaviour
    {
        [SerializeField] private GameObject Pupil;
        [SerializeField] private GameObject Eyelid;

        public void openEye()
        {
            StartCoroutine(openEyelid());
        }

        public void closeEye()
        {
            StartCoroutine(closeEyelid());
        }

        public Vector3 lookAt(Vector3 pos)
        {
            Vector3 dir = (transform.position - pos).normalized;
            Pupil.transform.position = transform.position + dir * 0.3f;
            return Pupil.transform.position;
        }

        public void lookAtCenter()
        {
            StartCoroutine(movePupil(new Vector3(0, 0, 0)));
        }

        private IEnumerator openEyelid()
        {
            while (Eyelid.transform.position.y <= transform.position.y + 3f)
            {
                Eyelid.transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Pupil.GetComponent<SpriteRenderer>().sortingLayerName = "Pupil";
            yield break;
        }

        private IEnumerator closeEyelid()
        {
            Pupil.GetComponent<SpriteRenderer>().sortingLayerName = "Eye";
            while (transform.position.y <= Eyelid.transform.position.y)
            {
                Eyelid.transform.position -= new Vector3(0, 1f, 0) * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Eyelid.transform.position = transform.position;
        }

        private IEnumerator movePupil(Vector3 pos)
        {
            float speed = 2f;
            Vector3 dir = pos - Pupil.transform.position.normalized;

            while(0.1f < (pos - Pupil.transform.position).magnitude)
            {
                Pupil.transform.position += dir * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Pupil.transform.position = pos;
            yield break;
        }
    }
}