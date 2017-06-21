using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObj : MonoBehaviour {
    private Score score;
    public int scorepoint=100;  //得られるスコア
    private bool flag;          //スコア獲得フラグ
    // Use this for initialization
    void Start () {
        score = GameObject.Find("Canvas/Score").GetComponent<Score>();
   
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 1, 0);

        if (flag && GetComponent<AudioSource>().isPlaying==false)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            if (!flag)
            {
                GetComponent<AudioSource>().Play();
                score.Registor(Score.ScoreTag.Item, 100);
                flag = true;
                transform.Find("Cube").GetComponent<MeshRenderer>().enabled = false;
                
            }
         
        }
    }
}