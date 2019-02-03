using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpaghettiMan : MonoBehaviour {

    public BoxCollider2D activatingTrigger;
    public bool isMoving;
    public BoxCollider2D activatingTrigger2;
    public BoxCollider2D weaponHitBox;
    GameObject player;
    public SpriteRenderer whipBack;
    public SpriteRenderer whipForward;
    public bool isAttacking;

    public static float HP;

    public GameObject breadcrumb;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isMoving = false;
        weaponHitBox.enabled = false;
        HP = 2.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        if(isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
        }
        
        if(HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(breadcrumb, new Vector3(transform.position.x + Random.Range(-.37f, .37f), transform.position.y + Random.Range(0, 1f), transform.position.z), Quaternion.identity);
            Instantiate(breadcrumb, new Vector3(transform.position.x + Random.Range(-.37f, .37f), transform.position.y + Random.Range(0, 1f), transform.position.z), Quaternion.identity);
            Instantiate(breadcrumb, new Vector3(transform.position.x + Random.Range(-.37f, .37f), transform.position.y + Random.Range(0, 1f), transform.position.z), Quaternion.identity);
        }
    }


    IEnumerator Attack()
    {
        isMoving = false;   //stop moving
        yield return new WaitForSeconds(0.25f);
        isAttacking = true;
        whipBack.enabled = true;    //start whip animation(pulling whip back)
        yield return new WaitForSeconds(0.6f);
        whipBack.enabled = false;
        whipForward.enabled = true;    //send whip forward animation
        yield return new WaitForSeconds(0.05f);
        weaponHitBox.enabled = true;    //enable hitbox after short delay
        yield return new WaitForSeconds(0.05f);
        weaponHitBox.enabled = false;   //disable hitbox while whip is still out
        yield return new WaitForSeconds(0.75f);
        whipForward.enabled = false;    //pull back whip animation (or just make invisible idk)
        isMoving = true;
        isAttacking = false;
        activatingTrigger2.enabled = true;  //re-enable trigger to determine if going to attack again

    }

    IEnumerator DeactivateActivatingMovementTrigger()
    {
        activatingTrigger.enabled = false;
        yield return new WaitForSeconds(.25f);
        isMoving = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if player gets in range of spaghettiman, trigger spaghettiman move towards player
        if (other.gameObject.name == "Player" && isMoving == false && isAttacking == false)
        {
            StartCoroutine(DeactivateActivatingMovementTrigger());
        }

        if (other.gameObject.name == "Player" && isMoving == true && isAttacking == false)
        {
            activatingTrigger2.enabled = false;
            StartCoroutine(Attack());
        }

        if (other.gameObject.name == "Player" && isMoving == false && isAttacking == true)
        {
            PlayerMovement.HP -= 2.5f;    //hit player
            player.transform.position = new Vector3(player.transform.position.x - 5f, player.transform.position.y, player.transform.position.z);
        }


        //spaghetti man gets knocked back when spoon hits it
        if (other.gameObject.name == "WoodenSpoon_Hitbox" /* || any other weapon equipped?*/)
        {
            HP -= 0.5f;
            transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z);
        }

    }


}
