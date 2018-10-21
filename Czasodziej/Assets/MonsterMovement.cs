using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed;
    public Vector2 cos;
    private Rigidbody2D rb;
    private bool lr = true;
    PlayerController refScript;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        refScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, refScript.position, step);

            if (speed > 5) speed -= 0.005f;
        }

        else if (speed <=30) speed += 0.02f;
    }
}
