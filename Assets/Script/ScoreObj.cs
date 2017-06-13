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
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            Destroy(this.gameObject);
            if (!flag)
            {
                score.Registor(Score.ScoreTag.Item, 100);
                flag = true;
            }
        }
    }
}