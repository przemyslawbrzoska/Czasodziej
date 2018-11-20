using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {


    public AudioClip sound;
    public AudioSource source;

    bool isplay = false;
    
    // Use this for initialization
	void Start () {

        source.clip = sound;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {


	}


}
