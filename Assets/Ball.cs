using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballSpeed = 9;
    public Rigidbody2D rb;
    float velX;
    float velY;
    public GameObject scoreUI1;
    public GameObject scoreUI2;
    public GameObject endText;
    public string p1Wins = "Player 1 wins !";
    public string p2Wins = "Player 2 wins !";

    public int scoreP1;
    public int scoreP2;

    Vector2 startPosition;
    public Vector2 positionUpdate;

    Vector2 BallSpeedDef()
    {
        velX = Random.Range(0.75f, 1.25f) * ballSpeed;
        velY = Random.Range(0.75f, 1.25f) * ballSpeed;

        Vector2 generalVel = new Vector2(velX, velY);

        return generalVel;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        rb.velocity = BallSpeedDef();
    }

    // Update is called once per frame
    void Update()
    {
        positionUpdate = transform.position;

        if (scoreP1 >= 7)
        {
            endText.GetComponent<TextMesh>().text = p1Wins;
            Destroy(this.gameObject);
        }

        if (scoreP2 >= 7)
        {
            endText.GetComponent<TextMesh>().text = p2Wins;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            float rdmNbr = Random.Range(-0.25f, 0.25f);
            velX = -velX + rdmNbr;
            rb.velocity = new Vector2(velX, velY);
        }

        else if (collision.gameObject.name == "UpWall" || collision.gameObject.name == "DownWall")
        {
            velY = -velY;
            rb.velocity = new Vector2(velX, velY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "P2Goal")
        {
            scoreP1 += 1;
            scoreUI1.GetComponent<TextMesh>().text = scoreP1.ToString();
            rb.velocity = BallSpeedDef();
            transform.position = startPosition;
        }

        else if (collision.gameObject.name == "P1Goal")
        {
            scoreP2 += 1;
            scoreUI2.GetComponent<TextMesh>().text = scoreP2.ToString();
            rb.velocity = BallSpeedDef();
            transform.position = startPosition;
        }
    }
}
