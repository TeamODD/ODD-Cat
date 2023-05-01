using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;

    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        /*if (h < 0)
        {
            sp.flipX = true;
            pAnimator.SetBool("Move_H", true);
        }
        else if (0 < h)
        {
            sp.flipX = false;
            pAnimator.SetBool("Move_H", true);
        }
        else if (h == 0)
        {
            pAnimator.SetBool("Move_H", false);
        }*/

        /*if (v < 0)
        {
            pAnimator.SetInteger("Move_V", -1);
        }
        else if (0 < v)
        {
            pAnimator.SetInteger("Move_V", 1);
        }
        else if (v == 0)
        {
            pAnimator.SetInteger("Move_V", 0);
        }*/

        // can't escape from circle on center
        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.Rotate((new Vector3(h, v, 0).normalized) * Time.deltaTime, Space.World);
    }
}
