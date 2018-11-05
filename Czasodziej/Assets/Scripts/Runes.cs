using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runes : MonoBehaviour {
    [SerializeField]
    GameObject earthRune;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            RuneOfTheEarth();
        }
	}

    void RuneOfTheEarth()
    {
        var earth = Instantiate(earthRune);
        earth.transform.position = transform.position;
        earth.transform.rotation = transform.rotation;

        var earthRb = earth.GetComponent<Rigidbody2D>();

    }
}
