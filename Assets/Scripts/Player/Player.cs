using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    private float h, v;
    private bool isDash;

    // Start is called before the first frame update
    void Start()
    {
        isDash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDash)
            return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        rotate(h, v);
        move(h, v);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(dash(h, v));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Boolet"))
        {
            Destroy(col.gameObject);
            StartCoroutine(runHitEvent());
        }
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

    private IEnumerator dash(float h, float v)
    {
        isDash = true;
        Vector3 unit = new Vector3(h, v, 0).normalized;
        float dashSpeed = 23f;

        while(speed < dashSpeed)
        {
            transform.position += unit * dashSpeed * Time.deltaTime;
            dashSpeed -= 0.1f;
            yield return new WaitForEndOfFrame();
        }

        isDash = false;
    }

    private void rotate(float h, float v)
    {
        if (h == 0 && v == 0) return;
        if (!isMoveKeyDown()) return;
        Vector3 dir = new Vector3(v, h*-1, 0).normalized;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    }

    private bool isMoveKeyDown()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    private IEnumerator runHitEvent()
    {
        for(int i=0; i<10; i++)
        {
            setAlpha(0.5f);
            yield return new WaitForSeconds(0.1f);

            setAlpha(1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void setAlpha(float a)
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Color c = sp.color;
        c.a = a;
        sp.color = c;
    }
}
