using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostTutorialScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Resources.UnloadUnusedAssets();
            SceneManager.UnloadSceneAsync("PostTutorial");
            AsyncOperation async = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        }
    }
}
