using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScore : MonoBehaviour {

    public float popNetxTime;
    public GameObject enemy;

    private float elapsedTime;

    float enemyPopPosX;
    float enemyPopPosY;

	// Use this for initialization
	void Start () 
    {

        elapsedTime = 0;

	}
	
	// Update is called once per frame
	void Update () 
    {

        elapsedTime += Time.deltaTime;

        if(elapsedTime > popNetxTime)
        {
            elapsedTime = 0f;
            
            PopEnemy ();
        }
	}

    void PopEnemy()
    {
         //エネミー出現位置決定
	    enemyPopPosX = Random.Range(20.0f, 40.0f);
        enemyPopPosY = Random.Range(-2.0f, 2.0f);


        //出現処理
        Instantiate(enemy, new Vector2(enemyPopPosX, enemyPopPosY), Quaternion.identity);

    }
}
