using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 position;
    private KeyCode latestKey;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Vector2 movement = new Vector2(moveHorizonal, moveVertical);
        //rb2d.AddForce(movement*speed);

        Movement();
    }

    private void setAnimationProperties(Vector2 movementVector, bool isMoving)
    {
        anim.SetBool("walking", isMoving);
        anim.SetFloat("speed_x", Math.Sign(movementVector.x));
        anim.SetFloat("speed_y", Math.Sign(movementVector.y));
    }

    bool isPlayerMoving()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            return true;
        else return false;
    }


void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            setAnimationProperties(Vector2.left, true);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            setAnimationProperties(Vector2.right, true);
        }

        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            setAnimationProperties(Vector2.up, true);
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            setAnimationProperties(Vector2.down, true);
        }
        else
        {
            setAnimationProperties(Vector2.zero, false);
        }
        position = rb2d.transform.position;
    }
}
