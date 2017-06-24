using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManeger : MonoBehaviour
{
    [SerializeField]
    private Canvas select_canvas;
    [SerializeField]
    private Canvas start_canvas;

    private void Start()
    {
        select_canvas.enabled = false;
    }

    public void EnableSelectCanvas()
    {
        start_canvas.enabled = false;
        select_canvas.enabled = true;
    }

    public void EnableStartCanvas()
    {
        start_canvas.enabled = true;
        select_canvas.enabled = false;
    }

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
