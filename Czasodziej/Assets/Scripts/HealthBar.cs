using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {

        PlayerController player;
        Vector2 localScale;

        public static float SCALE = 8;

        // Use this for initialization
        void Start()
        {
            localScale = transform.localScale;
            player = GetComponentInParent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            localScale.x = player.healthAmount * SCALE;
            transform.localScale = localScale;
        }
    }
}



