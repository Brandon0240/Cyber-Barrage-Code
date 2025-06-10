using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {

    public GameObject playerObject;
    private int followSpeed = 100 ;
    public Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        targetPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        //targetPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -10);//follow the player
        targetPosition = new Vector3(playerObject.transform.position.x, 0, -10);
        transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
	}
}
