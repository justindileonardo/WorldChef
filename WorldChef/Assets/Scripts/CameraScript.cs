using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public PlayerMovement playerScript;
    public float lerpSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerScript.transform.position.x, /*playerScript.*/transform.position.y, transform.position.z), lerpSpeed);
    }
}
