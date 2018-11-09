using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour {

    PlayerController refScript;
    private bool displayMessage = false;
    readonly string message = "";
    GUIStyle gUIStyle = new GUIStyle();
    // Use this for initialization
    void Start () {
        refScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherObject = collision.gameObject.name;

        if (otherObject == "Player") displayMessage = true;

        Debug.Log("Kolizja z " + otherObject);
    }
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

        SceneManager.LoadScene("Level1");
        yield return new WaitForSeconds(1f);
        
    }
    
}
