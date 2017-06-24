using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManeger : MonoBehaviour
{

    public void LoadScene1()
    {
        SceneManager.LoadScene("StageTown");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("stage2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("");
    }
}
