using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManeger : MonoBehaviour
{

    [SerializeField]
    private Text textCountdown;

    [SerializeField]
    private Image imageMask;

    void Start()
    {
        textCountdown.text = "";
        textCountdown.gameObject.SetActive(false);
        imageMask.gameObject.SetActive(false);
    }

    //カウントダウンタイマー
    private IEnumerator CountdownCoroutine(string scene_name)
    {
        imageMask.gameObject.SetActive(true);
        textCountdown.gameObject.SetActive(true);

        textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(scene_name);
    }

    public void LoadScene1()
    {
        StartCoroutine(CountdownCoroutine("StageTown"));
    }

    public void LoadScene2()
    {
        StartCoroutine(CountdownCoroutine("stage2"));
    }

    public void LoadScene3()
    {
        StartCoroutine(CountdownCoroutine(""));
    }
}
