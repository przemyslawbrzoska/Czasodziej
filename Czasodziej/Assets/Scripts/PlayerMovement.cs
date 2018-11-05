using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a"))
        {
            Vector2 movement = new Vector2(-1,0) ;
            rb.MovePosition(movement);
        }
        if (Input.GetKey("d"))
        {
            Vector2 movement = new Vector2(1, 0);
            rb.MovePosition(movement);
        }
        if (Input.GetKey("w"))
        {
            Vector2 movement = new Vector2(0, 1);
            rb.MovePosition(movement);
        }
        if (Input.GetKey("w"))
        {
            Vector2 movement = new Vector2(0, -1);
            rb.MovePosition(movement);
        }
    }
}
