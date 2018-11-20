using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    //public float speed = 5.0f;
    //private float step;
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherObject = collision.gameObject.name;

        if (otherObject == "Player") displayMessage = true;

        Debug.Log("Kolizja " +this.name +" z " + otherObject);
    }

 /*   private void OnCollisionStay2D(Collision2D collision)
    {
        transform.Translate(Vector2.up * step);
    }*/

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
}
