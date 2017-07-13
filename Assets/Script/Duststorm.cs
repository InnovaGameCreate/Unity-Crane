using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duststorm : MonoBehaviour {
    private float time = 0;
    private ParticleSystem storm;
    private AudioSource sound1;
    private AudioSource sound2;
    private TargetStatus boxst;  //箱状態
    //private TargetStatus damage;

    void Start () {
        storm = GetComponent<ParticleSystem>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound1 = audioSources[0];
        sound2 = audioSources[1];

        //damage = GetComponent<TargetStatus>();

        //初期値のランダム設定
        transform.position = new Vector3(Random.Range(30.0f, 420.0f), 2, Random.Range(30.0f, 420.0f));

        boxst = GameObject.Find("運ぶ物").GetComponent<TargetStatus>();

    }

    private void Update()
    {
        time += Time.deltaTime;
        //enabled = !enabled;
        if(time >= 5.0 && time < 10.0)
        {
            sound1.Play();
        }
        else if (time >= 10.0 && time < 20.0)
        {
            storm.Play();
            sound2.Play();
        }
        else if (time >= 20.0)
        {
            storm.Stop();
            storm.Clear();
            time = 0;
            transform.position = new Vector3(Random.Range(30.0f, 420.0f), 2, Random.Range(30.0f, 420.0f));
        }
    }

    //竜巻に入っているときにダメージを受ける
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MovableObj"))
        {
            //damage.
            boxst.dust();
        }
    }
}
