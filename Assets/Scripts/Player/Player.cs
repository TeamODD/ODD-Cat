using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private float h, v;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        move();
        rotate();
    }

    public void move()
    {
        //transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;

    }

    public void rotate()
    {

        Vector3 dir = new Vector3(h, v, 0).normalized;
        Debug.Log(transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg - 90));
    }
}
