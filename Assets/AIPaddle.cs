using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float speed2 = 0.007f;
    public Transform location2;
    public Rigidbody2D rigidBody2;
    public GameObject ballRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRef.transform.position.y > location2.position.y)
        {
            MoveUp();
        }

        else if (ballRef.transform.position.y < location2.position.y)
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        location2.position = new Vector2(7.7f, location2.position.y + speed2);

        if (location2.position.y > 3.795)
        {
            location2.position = new Vector2(location2.position.x, 3.795f);
        }
    }

    void MoveDown()
    {
        location2.position = new Vector2(7.7f, location2.position.y - speed2);

        if (location2.position.y < -3.795)
        {
            location2.position = new Vector2(location2.position.x, -3.795f);
        }
    }
}
