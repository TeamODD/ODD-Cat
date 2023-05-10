using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0f;
        // EditorApplication.isPaused = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onExitPause();
        }
    }
    public void onExitPause()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void onExitGame()
    {
        Application.Quit();
    }

}
