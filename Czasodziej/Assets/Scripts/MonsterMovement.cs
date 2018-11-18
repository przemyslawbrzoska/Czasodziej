using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    public float speed;
    private float step;
    private Rigidbody2D rb;
    private bool displayMessage = false;
    PlayerController refScript;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        refScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }


    void Movement()
    {

        if (!isPlayerMoving())
        {
            step = speed * Time.deltaTime;
            Vector2 movementVector = refScript.position - rb.position;
            transform.position = Vector2.MoveTowards(transform.position, refScript.position, step);

            setAnimationProperties(movementVector, true);
            if (speed > 5) speed -= 0.005f;
        }
        else
        {
            setAnimationProperties(Vector2.zero, false);
            if (speed <= 30)
            {
                speed += 0.02f;
            }
        }
    }

    private void setAnimationProperties(Vector2 movementVector,bool isMoving)
    {
        anim.SetBool("walking", isMoving);
        anim.SetFloat("speed_x", Math.Sign(movementVector.x));
        anim.SetFloat("speed_y", Math.Sign(movementVector.y));
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherObject = collision.gameObject.name;

        if (otherObject == "Player") displayMessage = true;

        Debug.Log("Kolizja " +this.name +" z " + otherObject);
    }

    // w przypadku kolizji przesuwa się w prawo - to takie prowizoryczne rozwiązanie, w przyszłości trzeba umożliwić przesuwanie się w różne strony
    // w zależności jak chcemy ominąć przeszkodę (bo nie zawsze przesunięcie w prawo umożliwia ominięcie przeszkodu

    //niestety czasami potwór wychodzi za planszę przez to przesunięcie
    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.Translate(Vector2.up * step);
    }

    readonly string message = "DEAD!";
    GUIStyle gUIStyle = new GUIStyle();

    // jak odkomentujemy poniższą funkcję to będzie komunikat DEAD przy kolizji potwora i playera
    public void OnGUI()
     {
         gUIStyle.fontSize = 40;
         if (displayMessage)
         {
             GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message, gUIStyle);
            StartCoroutine(waitAndRestart());
        }
    }

    public IEnumerator waitAndRestart()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("SampleScene");
    }
    bool isPlayerMoving()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            return true;
        else return false;

    }
}
