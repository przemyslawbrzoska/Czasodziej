using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovementOld : MonoBehaviour
{
    public float speed = 5.0f;
    private float step;
    public Vector2 cos;
    private Rigidbody2D rb;
    private bool displayMessage = false;
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
        //bool go = true;
        if (!isPlayerMoving())
        {
            step = speed * Time.deltaTime;
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, refScript.position,step);

           // if (hit.collider != null) {

               // go = false;
                //isHit = false;
                //Destroy(GameObject.Find(hit.collider.gameObject.name));
           /// } else go = true;
            //transform.position = Vector2.MoveTowards(transform.position, refScript.position, step);

           // if(go)
            {   
                transform.position = Vector2.MoveTowards(transform.position, refScript.position, step);
            }
            if (speed > 5) speed -= 0.005f;
        }
        else if (speed <= 30) speed += 0.02f;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherObject = collision.gameObject.name;

        if (otherObject == "Player") displayMessage = true;

        Debug.Log("Kolizja " + this.name + " z " + otherObject);

        //transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.up, step);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        //transform.Translate(Vector2.up * step);
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
