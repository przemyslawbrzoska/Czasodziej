using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    GameObject earth;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            RuneOfTheEarth();
        }
    }

    void RuneOfTheEarth()
    {
        var runeOfTheEarth = Instantiate(earth);
        var earthRb = runeOfTheEarth.GetComponent<Rigidbody2D>();

        earthRb.velocity = transform.right;
    }
}
