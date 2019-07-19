using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void ChangeExpainScene()
    {
        SceneManager.LoadScene("Explain");
    }

    //public void ChangeSettingScene()
    //{
    //    SceneManager.LoadScene("Setting");
    //}

    public void ChangeStartScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ChangeExitScene()
    {
        Debug.Log("End");
        Application.Quit();
    }
}
