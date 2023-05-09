using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePattern : MonoBehaviour
{
    [SerializeField] GameObject _parent = null;

    [SerializeField] GameObject _arrow = null;
    [SerializeField] GameObject _doubleArrow = null;
    [SerializeField] GameObject _gunArrow = null;

    public Transform playerPos = null;

    [SerializeField] GameObject[] _arrowLeftPos;

    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            arrowFattern();
        }

        int selectFattern = Random.Range(0, 5); // 4 = 여러 패턴 동시? 이건 나중에 패턴 더 만들고 할 거

        float fatternTime = Random.Range(2.0f, 5.0f);
        time += Time.deltaTime;
        if(time >= fatternTime)
        {
            arrowFattern();
            time = 0.0f;
        }

        
    }

    public Vector3 GetPlayerPos()
    {
        return playerPos.position;
    }

    public void arrowFattern()
    {
        StartCoroutine(EnumFunc_ArrowPattern());
    }
    // x : -910~910 y :-490 ~ 490
    IEnumerator EnumFunc_ArrowPattern()
    {
        int randomWhere = Random.Range(0, 2);

        int randomLeftX = Random.Range(0, 5);
        int randomRightX = Random.Range(5, 10);

        float goSpeed = 10.0f;

        if(randomWhere == 0) // left
        {
             GameObject go = Instantiate(_arrow, _arrowLeftPos[randomLeftX].transform.position, Quaternion.identity);
            go.transform.parent = _parent.transform;
            go.transform.Translate(new Vector3(1, 0, 0) * goSpeed * Time.deltaTime);
            //Debug.Log("소환");
            SetandShoot(go, new Vector3(20.0f, go.transform.position.y), 20.0f);
        }
        else // right
        {
            GameObject go = Instantiate(_arrow, _arrowLeftPos[randomRightX].transform.position, Quaternion.identity);
            go.transform.rotation = new Quaternion(go.transform.rotation.x, go.transform.rotation.y, -180, go.transform.rotation.w);
            go.transform.parent = _parent.transform;
            SetandShoot(go, new Vector3(-20.0f, go.transform.position.y), 20.0f);
        }

        yield return new WaitForSeconds(0.2f);
    }

    public void SetandShoot(GameObject go, Vector3 target, float speed)
    {
        //Debug.Log("함수호출");
        StartCoroutine(EnumFunc_SetandShoot(go, target, speed));
    }

    IEnumerator EnumFunc_SetandShoot(GameObject go, Vector2 target, float speed)
    {
        //Debug.Log("이넘호출");
        Vector2 dir = target - new Vector2(go.transform.position.x, go.transform.position.y);
        dir.Normalize();
        float time = 0;
        while (true)
        {        
            //Debug.Log("이넘반복");
            go.transform.Translate(dir * speed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.01f);

            time += Time.deltaTime;
            if (time >= 60.0f)
                Destroy(go.gameObject);
        }
    }
}
