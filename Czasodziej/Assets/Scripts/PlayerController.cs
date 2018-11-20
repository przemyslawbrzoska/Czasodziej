using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 position;
    //private KeyCode latestKey;
    private Animator anim;
    public float healthAmount;
    //private bool displayMessage = false;
    private SpriteRenderer sr;

    GUIStyle gUIStyle = new GUIStyle();
    private bool dead;

    // Use this for initialization
    void Start () {
        healthAmount = 1;
        dead = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (healthAmount <= 0)
        {
            dead = true;
        }
        else
        {
            sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 0.7f);
        }
    }

    public void OnGUI()
    {
        if (dead)
        {
            gUIStyle.fontSize = 40;
            string message = "YOU ARE DEAD!";
            GUI.Label(new Rect(Screen.width / 2 - 100f, Screen.height / 2, 200f, 200f), message, gUIStyle);
            StartCoroutine(waitAndRestart());
        }
    }

    public IEnumerator waitAndRestart()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("SampleScene");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    bool isPlayerMoving()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            return true;
        else return false;


    }

    private void setAnimationProperties(Vector2 movementVector, bool isMoving)
    {
        anim.SetBool("walking", isMoving);
        anim.SetFloat("speed_x", Math.Sign(movementVector.x));
        anim.SetFloat("speed_y", Math.Sign(movementVector.y));
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

    public static void BackToMenu()
    {
        ResumeGame();
        AsyncOperation async = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }

    internal void hit(float hit)
    {
        healthAmount -= hit;
        sr.color = new Color(2, 0, 0);
    }
}
