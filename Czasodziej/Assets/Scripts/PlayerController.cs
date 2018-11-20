using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 position;
    private KeyCode latestKey;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //float moveHorizonal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveHorizonal, moveVertical);
        //rb2d.AddForce(movement*speed);

        Movement();
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
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        position = rb2d.transform.position;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
    }

    public static void ResumeGame()
    {
        if (Time.timeScale == 0){
            SceneManager.UnloadSceneAsync("PauseMenu");
            Time.timeScale = 1;
        }
    }
}
