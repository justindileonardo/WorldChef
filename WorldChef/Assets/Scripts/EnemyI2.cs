using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyI2 : MonoBehaviour {

	public float moveSpeed, HP;
    //public bool moveLeft, moveRight;
    public bool moveTowardsPlayer;
    public GameObject ingredient2;
    public GameObject breadcrumb;
    public Transform playerPos;
    Vector3 enemyl1StartPos;
    public float attackTimer;

	// Use this for initialization
	void Start () {
        enemyl1StartPos = transform.position;
        moveTowardsPlayer = true;
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = GameObject.FindWithTag("Player").transform;

        attackTimer += Time.deltaTime;

        if(HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(ingredient2, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
        }
        if (attackTimer > 0.5f)
        {


            if (moveTowardsPlayer == true)
            {
                //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, enemyl1StartPos.y, transform.position.z),
                    new Vector3(playerPos.position.x, enemyl1StartPos.y, transform.position.z), moveSpeed * Time.deltaTime);
            }
        }
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackTimer >= 0.25f)
            {
                PlayerMovement.HP -= .5f;
                attackTimer = 0;

                if (PlayerMovement.direction == 1)
                {
                    playerPos.transform.position = new Vector3(playerPos.transform.position.x - 4f, playerPos.transform.position.y, playerPos.transform.position.z);
                }
                if (PlayerMovement.direction == -1)
                {
                    playerPos.transform.position = new Vector3(playerPos.transform.position.x + 4f, playerPos.transform.position.y, playerPos.transform.position.z);
                }

            }
        }
    }

}
