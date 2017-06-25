using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManeger : MonoBehaviour
{
    //ステージ
    public enum Stage { Town, Wilderness, Forest }

    //選択されたステージ
    [System.NonSerialized]
    public static Stage selected_stage;

    //カウントダウン音用
    private AudioSource audio_source;//AudioSource
    [SerializeField]
    private AudioClip countdown_se;
    [SerializeField]
    private AudioClip countdown_go_se;

    [SerializeField]
    private Text textCountdown;

    [SerializeField]
    private Image imageMask;

    void Start()
    {
        textCountdown.text = "";
        textCountdown.gameObject.SetActive(false);
        imageMask.gameObject.SetActive(false);
        audio_source = GetComponent<AudioSource>();
    }

    //カウントダウンタイマー
    private IEnumerator CountdownCoroutine(string scene_name)
    {
        imageMask.gameObject.SetActive(true);
        textCountdown.gameObject.SetActive(true);

        textCountdown.text = "3";
        audio_source.PlayOneShot(countdown_se);
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "2";
        audio_source.PlayOneShot(countdown_se);
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "1";
        audio_source.PlayOneShot(countdown_se);
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "GO!";
        audio_source.PlayOneShot(countdown_go_se);
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(scene_name);
    }

    public void LoadSceneTown()
    {
        selected_stage = Stage.Town;
        StartCoroutine(CountdownCoroutine("StageTown"));
    }

    public void LoadSceneWilderness()
    {
        selected_stage = Stage.Wilderness;
        StartCoroutine(CountdownCoroutine("stage2"));
    }

    public void LoadSceneForest()
    {
        selected_stage = Stage.Forest;
        StartCoroutine(CountdownCoroutine("unity-stage(forest) 1"));
    }
}
