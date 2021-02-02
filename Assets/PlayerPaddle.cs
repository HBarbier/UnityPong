using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed;
    public Transform location;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Vertical");
        rigidBody.velocity = new Vector2(0, speed * 6);

        if (location.position.y < -3.795f)
        {
            location.position = new Vector2(location.position.x, -3.795f);
        }

        else if (location.position.y > 3.795f)
        {
            location.position = new Vector2(location.position.x, 3.795f);
        }
    }
}
