using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TMP_InputField name;

    // Start is called before the first frame update
    public void onSave()
    {
        GameMgr.GetIns._Nickname = name.text;
        GameMgr.GetIns.SaveData();
        SceneManager.LoadScene("RankingScene");
    }
}
