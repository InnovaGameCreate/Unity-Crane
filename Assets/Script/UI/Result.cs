using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private Text time;
    private Text score;
    private Text hp;
    private Text total;
    private GameObject[] rank = new GameObject[4];
    private int rank_for_save;

    //ランク決定基準
    public int rankS_border;

    public int rankA_border;
    public int rankB_border;

    private bool scenechange;

    // Use this for initialization
    private void Start()
    {
        time = GameObject.Find("StartCanvas/残り時間：").GetComponent<Text>();
        score = GameObject.Find("StartCanvas/スコア：").GetComponent<Text>();
        hp = GameObject.Find("StartCanvas/荷物耐久値：").GetComponent<Text>();
        total = GameObject.Find("StartCanvas/TOTAL：").GetComponent<Text>();

        rank[0] = GameObject.Find("StartCanvas/rankS");
        rank[1] = GameObject.Find("StartCanvas/rankA");
        rank[2] = GameObject.Find("StartCanvas/rankB");
        rank[3] = GameObject.Find("StartCanvas/rankC");

        for (int i = 0; i < 4; i++)
            rank[i].SetActive(false);

        int timep = (((int)Timer.time_) * 10);
        time.text = "残り時間：" + ((int)Timer.time_).ToString() + " s" + " = " + timep.ToString() + " point";
        int scorep = (int)ScoreTotal.score_;
        score.text = "スコア：" + scorep.ToString() + " point";
        int hpp = (int)BoxGaugeNow.now_box_;
        hp.text = "荷物耐久値：" + (hpp * 10).ToString() + " point";
        int totalp = timep + scorep;
        total.text = "TOTAL：" + totalp.ToString() + " point";

        //ランク決め
        if (totalp > rankS_border)
        {
            rank[0].SetActive(true);
            rank_for_save = 'S';
        }
        else if (totalp > rankA_border)
        {
            rank[1].SetActive(true);
            rank_for_save = 'A';
        }
        else if (totalp > rankB_border)
        {
            rank[2].SetActive(true);
            rank_for_save = 'B';
        }
        else
        {
            rank[3].SetActive(true);
            rank_for_save = 'C';
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Play();
            scenechange = true;
        }
        if (scenechange && !GetComponent<AudioSource>().isPlaying)
        {
            PlayerPrefs.SetInt("" + StartSceneManeger.selected_stage, rank_for_save);//ランクをセーブ
            SceneManager.LoadScene("Start");
        }
    }
}