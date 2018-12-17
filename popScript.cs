using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popScript : MonoBehaviour {

    public float popNextTime;
    public GameObject enemy;

    private float elapsedTime;

    float enemyPopPosX;
    float enemyPopPosY;
    float popPosRam;

	// Use this for initialization
	void Start () {
        elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += Time.deltaTime;

        if(elapsedTime > popNextTime)
        {
            elapsedTime = 0f;

            PopEnemy();
        }
		
	}

    void PopEnemy()
    {
        //エネミー出現位置決定
        //enemyPopPosX = Random.Range(10.0f, 11.0f);
        popPosRam = Random.Range(0f, 1f);
        if (popPosRam > 0.5)
            enemyPopPosX = Random.Range(10.0f, 11.0f);
        else
            enemyPopPosX = Random.Range(-10.0f, -11.0f);

        enemyPopPosY = Random.Range(-2.0f, 4.0f);

        Instantiate(enemy, new Vector2(enemyPopPosX, enemyPopPosY), Quaternion.identity);
    }
}
