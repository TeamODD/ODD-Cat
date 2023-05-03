using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 8.0f;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * _playerSpeed * Time.deltaTime; 
        float vertical = Input.GetAxis("Vertical") * _playerSpeed * Time.deltaTime;
        Vector3 trans = new Vector3(horizontal, vertical);
        transform.Translate(trans, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Arrow")
        {
            Debug.Log("Arrow客 面倒1");
            Destroy(other.gameObject);
        }
        //if (other.gameObject.tag.Equals("Arrow"))
        //{
        //    Debug.Log("Arrow客 面倒2");
        //    Destroy(other.gameObject);
        //}
        //if (other.gameObject.CompareTag("Arrow"))
        //{
        //    Debug.Log("Arrow客 面倒3");
        //    Destroy(other.gameObject);
        //}
        //if (other.collider.gameObject.CompareTag("Arrow"))
        //{
        //    Debug.Log("Arrow客 面倒4");
        //    Destroy(other.gameObject);
        //}
    }
}
