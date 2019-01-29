using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour {

	public float moveSpeed, HP;
	public bool moveLeft, moveRight;
    public GameObject breadcrumb;
    Vector3 breadStartPos;
    float attackTimer;
    public Transform playerPos;

	// Use this for initialization
	void Start () {
		moveRight = true;
        HP = 2;
        breadStartPos = transform.position;
        attackTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = GameObject.FindWithTag("Player").transform;


        attackTimer += Time.deltaTime;

        if(HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
        }
        if (attackTimer >= 0.5f)
        {

            if (moveLeft == true)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                transform.localScale = new Vector3(1.5f, transform.localScale.y, transform.localScale.z);
            }
            if (moveRight == true)
            {
                transform.position += Vector3.left * -moveSpeed * Time.deltaTime;
                transform.localScale = new Vector3(-1.5f, transform.localScale.y, transform.localScale.z);
            }

            if (transform.position.x <= breadStartPos.x - 5 && moveLeft == true)
            {
                moveLeft = false;
                moveRight = true;
            }
            if (transform.position.x >= breadStartPos.x + 5 && moveRight == true)
            {
                moveRight = false;
                moveLeft = true;
            }
        }



	}

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attackTimer >= 1)
            {
                PlayerMovement.HP -= 1.0f;
                attackTimer = 0;
                if(PlayerMovement.direction == 1)
                {
                    playerPos.transform.position = new Vector3(playerPos.transform.position.x - 2.5f, playerPos.transform.position.y, playerPos.transform.position.z);
                }
                if (PlayerMovement.direction == -1)
                {
                    playerPos.transform.position = new Vector3(playerPos.transform.position.x + 2.5f, playerPos.transform.position.y, playerPos.transform.position.z);
                }
            }
        }
    }

}
