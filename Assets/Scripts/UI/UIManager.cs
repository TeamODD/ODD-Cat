using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static Icons.Icon;

public class UIManager : MonoBehaviour
{

    [SerializeField] public GameObject lifePrefab;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public GameObject background;
    [SerializeField] public GameObject play;
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject rewind;
    [SerializeField] public GameObject fastRewind;
    [SerializeField] public GameObject fastForward;

    private GameObject icon;
    private IconType iconType;
    private Image backgroundImage;
    private List<GameObject> lifeObjList;
    private Player playerScript;

    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        lifeObjList = new List<GameObject>();
        backgroundImage = background.GetComponent<Image>();

        initLife();
    }

    void Update()
    {
        score.text = GameMgr.GetIns._Score.ToString();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
        }
    }

    private void initLife()
    {
        Vector3 beginPos = new Vector3(-8f, 4.14f, 0);

        for (int i = 0; i < playerScript.HP; i++)
        {
            GameObject o = Instantiate(lifePrefab) as GameObject;
            o.transform.position = beginPos + new Vector3(i*1.2f, 0, 0);
            o.transform.SetParent(transform.parent);
            lifeObjList.Add(o);
        }
    }

    public void minusLife()
    {
        Destroy(lifeObjList[lifeObjList.Count - 1]);
        lifeObjList.RemoveAt(lifeObjList.Count - 1);
    }

    public void show(IconType i)
    {
        Color c = backgroundImage.color;
        c.a = 0.3f;
        backgroundImage.color = c;

        if(icon != null)
        {
            icon.SetActive(false);
        }

        iconType = i;
        switch (i)
        {
            case IconType.play:
                icon = play;
                c.a = 0f;
                backgroundImage.color = c;
                break;
            case IconType.pause:
                icon = pause;
                break;
            case IconType.rewind:
                icon = rewind;
                break;
            case IconType.fastRewind:
                icon = fastRewind;
                break;
            case IconType.fastForward:
                icon = fastForward;
                break;
            default:
                icon = null;
                return;
        }

        StartCoroutine(flicker(icon, i));
    }

    private IEnumerator flicker(GameObject icon, IconType i)
    {
        while(iconType == i)
        {
            icon.SetActive(true);
            yield return new WaitForSeconds(1f);
            icon.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
        icon.SetActive(false);
        yield break;
    }

    public void hide()
    {
        Color c = backgroundImage.color;
        c.a = 0f;
        backgroundImage.color = c;
        icon.SetActive(false);
        icon = null;
        iconType = IconType.none;
    }

    public void showGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
