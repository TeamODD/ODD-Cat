using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boolet
{
    public class SimpleArrow : MonoBehaviour
    {
        Vector3 unitV;
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
        }

        private void move()
        {
            if (unitV == null) return;
            transform.position += unitV * speed * Time.deltaTime;
        }

        private IEnumerator isMoveingOnCamera()
        {
            yield return new WaitForSeconds(1f);
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f || 1f < pos.x || pos.y < 0f || 1f < pos.y)
            {
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
            }
        }

        public void setUnit(Vector3 playerPos)
        {
            unitV = (playerPos - transform.position).normalized;
            rotate(unitV);
        }

        public void setSpeed(float s)
        {
            speed = s;
        }

        private void rotate(Vector3 v)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg);
        }
    }
}