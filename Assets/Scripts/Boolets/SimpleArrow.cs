using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boolet
{
    public class SimpleArrow : MonoBehaviour
    {
        private Vector3 dir;
        private float speed;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(isMoveingOnCamera());
        }

        // Update is called once per frame
        void Update()
        {
            move();
            speed = transform.GetComponentInParent<BooletController>().getSimpleArrowSpeed();
        }

        private void move()
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        private IEnumerator isMoveingOnCamera()
        {
            yield return new WaitForSeconds(2f);
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f || 1f < pos.x || pos.y < 0f || 1f < pos.y)
            {
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
            }
        }

        public void init(Vector3 targetPos)
        {
            setDir(targetPos);
        }

        private void setDir(Vector3 targetPos)
        {
            Vector3 vector = (targetPos - transform.position);
            dir = new Vector3(vector.x, vector.y, 0).normalized;
            rotate(dir);
        }

        private void rotate(Vector3 v)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg);
        }
    }
}