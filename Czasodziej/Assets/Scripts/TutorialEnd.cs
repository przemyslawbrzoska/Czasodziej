using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour {

    PlayerController refScript;
    GUIStyle gUIStyle = new GUIStyle();
    private bool displayMessage = false;
    void Start () {
		
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
           
            StartCoroutine(waitAndRestart());
        }
    }
    public IEnumerator waitAndRestart()
    {

        Resources.UnloadUnusedAssets();
        AsyncOperation async = SceneManager.LoadSceneAsync("PostTutorial", LoadSceneMode.Single);
        
        yield return new WaitForSeconds(1f);

    }
}
