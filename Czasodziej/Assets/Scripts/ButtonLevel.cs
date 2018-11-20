using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonInteract(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("MenuLevel", LoadSceneMode.Single);
    }
}
