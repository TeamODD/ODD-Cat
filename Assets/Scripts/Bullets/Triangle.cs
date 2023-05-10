using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class Triangle : MonoBehaviour
    {
        private Vector3 dir;
        public float speed;
        public BulletManager bulletManagerScript;

        void Update()
        {
            move();
            if (!isObjectInCamera())
            {
                Invoke("destroy", 3f);
            }
        }

        public void destroy()
        {
            Destroy(gameObject);
        }

        public void move()
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        public void init(Vector3 targetPos, float speed)
        {
            bulletManagerScript = transform.GetComponentInParent<BulletManager>();
            setDir(targetPos);
            setSpeed(speed);
        }

        public void multiplySpeed(float n)
        {
            speed *= n;
        }

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public float getSpeed()
        {
            return speed;
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

            if (pos.x < -2f || 3f < pos.x || pos.y < -2f || 3f < pos.y)
            {
                return false;
            }
            return true;
        }
    }
}