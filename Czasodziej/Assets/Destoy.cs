using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoy : MonoBehaviour {

    public float Time = 3f;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, Time);
    }
}
