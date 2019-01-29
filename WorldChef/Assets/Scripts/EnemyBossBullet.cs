using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBullet : MonoBehaviour {

    float moveSpeed = 15f;
    public float theDirection;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyBullet", 3);

        if (EnemyBoss.direction == 1)
        {
            theDirection = 1;
        }
        if (EnemyBoss.direction == 2)
        {
            theDirection = 2;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(theDirection == 1)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (theDirection == 2)
        {
            transform.position += -Vector3.left * moveSpeed * Time.deltaTime;
        }

    }

	void DestroyBullet(){
		Destroy (gameObject);
	}
}
