using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        move(h, v);
        rotate(h, v);
    }

    public void move(float h, float v)
    {
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
    }

    private void rotate(float h, float v)
    {
        if (h == 0 && v == 0) return;
        if (!isMoveKeyDown()) return;
        Vector3 dir = new Vector3(h*-1, v, 0).normalized;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg);
    }

    private bool isMoveKeyDown()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }
}
