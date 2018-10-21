using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed;
    private float step;
    public Vector2 cos;
    private Rigidbody2D rb;
    private bool displayMessage = true;
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
        // na razie tylko sprawdza czy używamy strzałek, trzeba dopisaić też WSAD
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, refScript.position, step);

            if (speed > 5) speed -= 0.005f;
        }

        else if (speed <=30) speed += 0.02f;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherObject = collision.gameObject.name;

        if (otherObject == "Player") displayMessage = true;

        Debug.Log("Kolizja z " + otherObject);
    }

    // w przypadku kolizji przesuwa się w prawo - to takie prowizoryczne rozwiązanie, w przyszłości trzeba umożliwić przesuwanie się w różne strony
    // w zależności jak chcemy ominąć przeszkodę (bo nie zawsze przesunięcie w prawo umożliwia ominięcie przeszkodu

    //niestety czasami potwór wychodzi za planszę przez to przesunięcie
    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.Translate(Vector2.right * step);
    }

    readonly string message = "DEAD!";
    GUIStyle gUIStyle = new GUIStyle();

    // jak odkomentujemy poniższą funkcję to będzie komunikat DEAD przy kolizji potwora i playera
    /* public void OnGUI()
     {
         gUIStyle.fontSize = 40;
         if (displayMessage)
         {
             GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message, gUIStyle);
         }
     }*/
}
