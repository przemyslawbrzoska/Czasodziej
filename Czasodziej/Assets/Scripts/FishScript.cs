using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {
    public Vector3 targetPosition = new Vector3(16.75F, 8.31F, 0);
    public Vector3 initialPosition = new Vector3(12.5F, 10F, 0);
    public float speed = 0.8F;
    PlayerController refScript;

    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();

    }
    void movement()

    {
        if (!isPlayerMoving())
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, Time.deltaTime * speed);

           
            if (transform.localPosition.x == targetPosition.x && transform.localPosition.y == targetPosition.y)
            {
                Vector3 temp = targetPosition;
                targetPosition = initialPosition;
                initialPosition = temp;
                transform.localScale += new Vector3(-1, 0, 0);
            }

        }
       
    }
    bool isPlayerMoving()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            return true;
        else return false;


    }
}
