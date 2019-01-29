using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour {

	public float HP;
	float shootTimer;
    float shootDelay = 3f;
	public bool bossGo;
	public GameObject bullet;
	public GameObject bossWeapon;
	public GameObject bossWeaponDrop;
    public GameObject breadcrumb;

    public bool bossMove;
    Vector3 bossStartPos;
    public Transform playerPos;
    public PlayerMovement playerScript;
    float moveSpeed;

    public float moveTimer;

    public static float direction;

    public Slider bossHpSlider;

    float attackMeleeTimer;

    public static bool bossDead;
    

    // Use this for initialization
    void Start () {
        bossStartPos = transform.position;
        bossMove = false;
        moveSpeed = 6f;
        moveTimer = 0;
        bossDead = false;
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = GameObject.FindWithTag("Player").transform;

        attackMeleeTimer += Time.deltaTime;

        if (transform.localScale.x == 2)
        {
            direction = 1;
        }
        else if (transform.localScale.x == -2)
        {
            direction = 2;
        }

        if (bossMove == true)
        {
            if(playerPos.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
            }
            else if (playerPos.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
            }
            //move towards player
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, bossStartPos.y, transform.position.z),
                    new Vector3(playerPos.position.x, bossStartPos.y, transform.position.z), moveSpeed * Time.deltaTime);
        }

        if (bossGo == true) {
            bossHpSlider.gameObject.SetActive(true);
            //Debug.Log ("Boss HP: " + HP);
            //Debug.Log(moveTimer);
			shootTimer += Time.deltaTime;
			if (shootTimer > shootDelay) {
				ShootBullet ();
				shootTimer = 0;
			}

                moveTimer += Time.deltaTime;
                if (moveTimer > 4f)
                {
                    bossMove = !bossMove;
                    moveTimer = 0;
                }

        }

        bossHpSlider.value = HP;

		if (HP <= 0) {
			bossGo = false;
			Destroy (gameObject);
			Destroy (bossWeapon);
            playerScript.progressBarSlider.value = 10;
			Instantiate (bossWeaponDrop, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            Instantiate(breadcrumb, transform.position, Quaternion.identity);
            bossDead = true;

        
        }

        if (bossDead)
        {

        }

	}
		
	void ShootBullet(){
		Debug.Log ("shoot");
		Instantiate (bullet, transform.position, Quaternion.identity);
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackMeleeTimer >= 1.5f)
            {
                PlayerMovement.HP -= 1.5f;
                attackMeleeTimer = 0;
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
