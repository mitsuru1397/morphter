using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bear_walk : MonoBehaviour {

    Rigidbody2D rb2d;
    private bool isJump = false;
    private bool isGround = true;
    private int jumpCount = 0;
    private int MAX_JUMP_COUNT = 2;
    private float moveeffect = 1.0f;
    private float jumpeffect = 1.0f;
    private float Dush = 1.0f;
    string state;
    string prevState;

    public Sprite[] animeSte = new Sprite[3];
    int jumpCheck = 0;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            jumpCount = 0;
            isGround = true;
            moveeffect = 1.0f;
            jumpeffect = 1.0f;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (rb2d.velocity.y > 0.3)
        {
            state = "JUMP";
            jumpCheck = 1;
            GetComponent<SpriteRenderer>().sprite = animeSte[jumpCheck];
        }
        else if (rb2d.velocity.y < 0.3)
        {
            state = "FALL";
            jumpCheck = 0;
            GetComponent<SpriteRenderer>().sprite = animeSte[jumpCheck];
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dush = 2.0f;
        }

        if (isGround == false || jumpCount > 1)
        {
            moveeffect = 0.6f;
            jumpeffect = 0.8f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Physics.gravity = new Vector2(0f, 0f);
            transform.Translate(new Vector3(-0.15f * moveeffect * Dush, 0.0f));
            transform.localScale = new Vector2(-1, 1);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Physics.gravity = new Vector2(0f, 0f);
            transform.Translate(new Vector3(0.15f * moveeffect * Dush, 0.0f));
            transform.localScale = new Vector2(1, 1);
        }

        if (jumpCount < MAX_JUMP_COUNT && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0.0f, 680.0f * jumpeffect));
            isGround = false;
            jumpCount++;
        }

        Dush = 1.0f;
    }
}