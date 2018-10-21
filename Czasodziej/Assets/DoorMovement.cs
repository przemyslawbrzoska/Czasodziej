using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {
    public Vector2 increaseValues = new Vector2(0.1F, 0.1F);
    public Vector3 targetPostion = new Vector3(16.75F, 8.31F, 0);
    public float speed = 0.1F;

    private Rigidbody2D rb2d;
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPostion, Time.deltaTime * speed);
            
    }
}
