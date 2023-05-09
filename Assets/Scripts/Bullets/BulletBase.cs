using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletBase : MonoBehaviour
    {
        private Vector3 dir;
        public float speed;
        public BulletManager bulletManagerScript;

        public void destroy()
        {
            Destroy(gameObject);
        }

        public void move()
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        public void init(Vector3 targetPos)
        {
            bulletManagerScript = transform.GetComponentInParent<BulletManager>();
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

        public bool isObjectInCamera()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < -1.5f || 2.5f < pos.x || pos.y < -1.5f || 2.5f < pos.y)
            {
                return false;
            }
            return true;
        }
    }
}
