using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    //public Vector3 targetPosition = new Vector3(16.75F, 8.31F, 0);
    public Transform Player;
    public Quaternion MissionDirection;

    public RectTransform MissionLayer;

    public Transform MissionPlace;
	
    public void ChangeCompassDirection()
    {
        Vector3 dir = transform.position - MissionPlace.position;

        MissionDirection = Quaternion.LookRotation(dir);

        MissionDirection.z = -MissionDirection.y;
        MissionDirection.x = 0;
        MissionDirection.y = 0;

        MissionLayer.localRotation = MissionDirection;
    }

	// Update is called once per frame
	void Update () {
        ChangeCompassDirection();
	}
}
