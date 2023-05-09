using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{

    [SerializeField] GameObject _game = null;
    [SerializeField] Button _btnStart = null;
    [SerializeField] Image _panelImg = null;
    [SerializeField] GameObject _panel = null;
    [SerializeField] Sprite _changeSprite= null;
    [SerializeField] Image _teamodd = null;
    [SerializeField] Button _gameStartBtn = null;
    [SerializeField] Button _RankBtn = null;

    bool _isIntro = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameMgr.GetIns._isFirst)
        {
            _game.SetActive(false);
            _btnStart.onClick.AddListener(onClicked_btnStart); // 인트로 버튼
        }
        else
        {
            _btnStart.gameObject.SetActive(false);
            _panel.gameObject.SetActive(false);
            _teamodd.gameObject.SetActive(true);
            _gameStartBtn.gameObject.SetActive(true);
            _RankBtn.gameObject.SetActive(true);
        }
        _gameStartBtn.onClick.AddListener(onClicked_gameStartBtn); // 게임 시작 버튼
        _RankBtn.onClick.AddListener(onClicked_RankBtn); // 게임 시작 버튼
    }

    // Update is called once per frame
    void Update()
    {
        if(_isIntro)
        {
            // 메인화면
            _teamodd.gameObject.SetActive(true);
            _RankBtn.gameObject.SetActive(true);
            _gameStartBtn.gameObject.SetActive(true);
        }
    }

    public void onClicked_RankBtn()
    {
        //GameMgr.GetIns.LoadData();
        SceneManager.LoadScene("RankingScene");
    }

    public void onClicked_btnStart()
    {
        //Debug.Log("dd");

        _btnStart.GetComponent<Image>().sprite = _changeSprite;
        
        StartCoroutine(introFadeOut(3.0f));

        //_btnStart.interactable = false;
    }

    public void onClicked_gameStartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator introFadeOut(float time)
    {
        //Debug.Log("들어옴");
        Color color = _panelImg.color;
        while (color.a >= 0)
        {
            //Debug.Log(" color.a : " +color.a);
            color.a -= Time.deltaTime / time;
            _panelImg.color = color;
            yield return null;
        }
        StartCoroutine(introBtnFadeOut(2.0f));

        _game.SetActive(true);
        _panel.SetActive(false);
    }

    IEnumerator introBtnFadeOut(float time)
    {
        Color color = _btnStart.image.color;
        while (color.a >= 0)
        {
            //Debug.Log(" color.a : " +color.a);
            color.a -= Time.deltaTime / time;
            _btnStart.image.color = color;
            yield return null;
        }
        _btnStart.gameObject.SetActive(false);
        GameMgr.GetIns._isFirst = true;
        _isIntro = true;
    }

}
