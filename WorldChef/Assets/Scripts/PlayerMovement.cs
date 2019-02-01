using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed, upSpeed, gravityUp, gravityDown, jumpVelocity, downVelocityMax, breadcrumbs;
    public static float HP;
    public static float direction;
    public float targetMoveSpeed;
    Vector3 startPos;

	Rigidbody2D rb;
	Vector2 velocity;
	public bool onTopOfPlatform;
	public LayerMask groundLayers;

    public Camera camera;

    public Level1 level1Script;
    public Level2 level2Script;
	GameObject attackBox;
	public EnemyI1 EnemyI1Script;
	public EnemyBoss EnemyBossScript;

    public Text textHP;
    public Text textBreadcrumbs;

    public bool healingAuto;

    public Slider progressBarSlider;

    public float enemyBasicTimer;

    public Animator playerAnimator;
    public bool isWalking;
    public bool isAttacking;
    public bool canWalk;
    float attackCD;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        HP = 10;
		rb = GetComponent<Rigidbody2D> ();
        healingAuto = false;
        //progressBarSlider.value = 0;
        canWalk = true;
	}

    // Update is called once per frame
    void Update () {

        

        if (transform.localScale.x == 1)
        {
            direction = 1;
        }
        else if (transform.localScale.x == -1)
        {
            direction = 2; 
        }
        //playerObjTransform = transform.position;

        if(HP <= 0)
        {
            transform.position = startPos;
            HP = 10;
            breadcrumbs = 0;
        }

        textHP.text = "HP: " + HP;
        textBreadcrumbs.text = "Crumbs: " + breadcrumbs;
        //print (HP);
        if(canWalk == true)
        {
            targetMoveSpeed = Input.GetAxisRaw("Horizontal") * speed;
        } 
        else
        {
            targetMoveSpeed = 0;
        }
        

        if (/*Input.GetKey(KeyCode.D)*/targetMoveSpeed > 0)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            
        }
        if (targetMoveSpeed < 0)
        {
            transform.position += -Vector3.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        

        //animation states
        if(targetMoveSpeed != 0 && isWalking == false && canWalk == true)
        {
            playerAnimator.SetBool("isWalking", true);
            isWalking = true;
        }
        else if(targetMoveSpeed == 0 && isWalking == true)
        {
            playerAnimator.SetBool("isWalking", false);
            isWalking = false;
        }
        
        
        //checks for being grounded
        //https://www.youtube.com/watch?v=MFM_-wlwRag
        onTopOfPlatform = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 2.2f), 
			new Vector2 (transform.position.x + 0.5f, transform.position.y - 2.21f), groundLayers);

		//gravity logic
		if (onTopOfPlatform == false) {
			//if the player is going up
			if (velocity.y > .5f) {
				velocity.y -= gravityUp * Time.deltaTime;
				//if the player is going down
			} else {
				velocity.y -= gravityDown * Time.deltaTime;
			}
		}
		//check if we went below the maximum down velocity
		if (velocity.y < -downVelocityMax) {
			velocity.y = -downVelocityMax;
		}
        //print(onTopOfPlatform);
		//jump logic
		if (Input.GetButtonDown ("Jump") == true && onTopOfPlatform == true) {
			velocity.y = jumpVelocity;
            print("jump");
		}

		rb.MovePosition (rb.position + velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.O))
        {
            healingAuto = true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            healingAuto = false;;
        }
        if (HP > 10)
        {
            HP = 10;
        }
        if (healingAuto == false)
        {
            //healing manual
            if (HP < 10 && breadcrumbs > 0 && Input.GetKeyDown(KeyCode.C))
            {
                HP++;
                breadcrumbs--;
            }
            if (HP > 10)
            {
                HP = 10;
            }
        }
        //reset values
        //onTopOfPlatform = false;

        enemyBasicTimer += Time.deltaTime;

	}

    void FixedUpdate()
    {

        //attack cooldown
        attackCD += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && attackCD > 1.0f)
        {
            //attack
            PlayAttackAnimation();
        }
    }

    public void PlayAttackAnimation()
    {
        StartCoroutine(AttackAnimation());
    }
    IEnumerator AttackAnimation()
    {
        canWalk = false;
        playerAnimator.SetBool("isWalking", false);
        playerAnimator.SetBool("isAttacking", true);
        isAttacking = true;
        attackCD = 0;
        yield return new WaitForSeconds(.50f);
        isAttacking = false;
        playerAnimator.SetBool("isAttacking", false);
        canWalk = true;
    }

    //Draw the OverLapArea
    void OnDrawGizmos(){
		Gizmos.color = new Color (0, 0, 1, 0.5f);
		Gizmos.DrawCube (new Vector2 (transform.position.x, transform.position.y - 2.2f), new Vector2 (1, 0.05f));
	}

	void OnCollisionEnter2D(Collision2D other){
        //pick up breadcrumb
        if (other.gameObject.tag == "Breadcrumb")
        {
            Destroy(other.gameObject);
            breadcrumbs++;
            if (healingAuto == true && HP <= 10)
            {
                HP++;
                breadcrumbs--;
            }
		}
        //pick up ingredient 1
        if (other.gameObject.tag == "Ingredient1")
        {
            Destroy(other.gameObject);
            Debug.Log("You have acquired ingredient 1!");
        }
        if (other.gameObject.tag == "Ingredient2") {
			Destroy (other.gameObject);
			Debug.Log ("You have acquired ingredient 2!");
		}
		if (other.gameObject.tag == "EnemyBossBullet") {
			HP -= 1;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "BossWeaponDrop") {
			Destroy (other.gameObject);
			Debug.Log ("You have defeated (X Boss) and obtained the (X Weapon)!");
		}
	}

	void OnCollisionStay2D(Collision2D other)
    {

	}

	void OnTriggerEnter2D(Collider2D other){
		//if hit platform 2 trigger point, enable the enemy to move and disable trigger
		if (other.gameObject.name == "Platform2Trigger") {
            level1Script.SpawnEnemyl1_1();
			GameObject.Find ("Platform2Trigger").GetComponent<BoxCollider2D> ().enabled = false;
		}
        if (other.gameObject.name == "Platform2Trigger2")
        {
            level2Script.SpawnEnemyl2_1();
            GameObject.Find("Platform2Trigger2").GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "Platform2TriggerB")
        {
            level1Script.SpawnEnemyl1_2();
            GameObject.Find("Platform2TriggerB").GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "Platform2TriggerB2")
        {
            level2Script.SpawnEnemyl2_2();
            GameObject.Find("Platform2TriggerB2").GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "Platform2TriggerC")
        {
            level1Script.SpawnEnemyl1_3();
            GameObject.Find("Platform2TriggerC").GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "Platform2TriggerC2")
        {
            level2Script.SpawnEnemyl2_3();
            GameObject.Find("Platform2TriggerC2").GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "BossStartTrigger") {
			EnemyBossScript.bossGo = true;
			GameObject.Find ("BossStartTrigger").GetComponent<BoxCollider2D> ().enabled = false;
		}
        if(other.gameObject.name == "TriggerProgressBar1")
        {
            progressBarSlider.value = 1.25f;
        }
        if (other.gameObject.name == "TriggerProgressBar2")
        {
            progressBarSlider.value = 2.5f;
        }
        if (other.gameObject.name == "TriggerProgressBar3")
        {
            progressBarSlider.value = 3.75f;
        }
        if (other.gameObject.name == "TriggerProgressBar4")
        {
            progressBarSlider.value = 5.0f;
        }
        if (other.gameObject.name == "TriggerProgressBar5")
        {
            progressBarSlider.value = 6.25f;
        }
        if (other.gameObject.name == "TriggerProgressBar6")
        {
            progressBarSlider.value = 7.5f;
        }
        if (other.gameObject.name == "TriggerProgressBar7")
        {
            progressBarSlider.value = 8.75f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            if (Input.GetKey(KeyCode.W))
            {
                gravityUp = 0;
                gravityDown = 0;
                transform.position += Vector3.up * Time.deltaTime * upSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gravityUp = 0;
                gravityDown = 0;
                transform.position += -Vector3.up * Time.deltaTime * upSpeed;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            gravityUp = 10;
            gravityDown = 12;
        }
    }



}
