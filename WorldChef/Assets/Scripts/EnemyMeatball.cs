using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeatball : MonoBehaviour {

    public float moveSpeed;
    public bool isActive;
    public bool isHit;
    public float explodingTimer;
    public BoxCollider2D activatingTrigger;

    public float explosionRadius;
    GameObject player;

    public GameObject ExplosionAnimation;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        //if player triggers meatball range, make active = count timer down to explosion
        if(isActive == true)
        {
            explodingTimer -= Time.deltaTime;
        }

        //if not hit by players weapon yet, move left
        if(isActive == true && isHit == false)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        //if hit by players weapon, knock back right
        else if(isActive == true && isHit == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), .2f);
        }

        //if exploding timer runs out, stop moving and blow up
        if(explodingTimer < 0f && isActive == true)
        {
            isActive = false;
            Explode();
        }

    }

    public void Explode()
    {
        if (explosionRadius >= Vector3.Distance(transform.position, player.transform.position))
        {
            print("hit player");
        }
        else
        {
            print("didnt hit player");
        }
        StartCoroutine(DestroyMeatballObject());
    }

    IEnumerator DestroyMeatballObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        ExplosionAnimation.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        ExplosionAnimation.SetActive(false);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if player gets in range of meatball, trigger meatball charge
        if(other.gameObject.name == "Player" && isActive == false)
        {
            activatingTrigger.enabled = false;
            isActive = true;
        }

        //meatball gets knocked back when spoon hits it
        if (other.gameObject.name == "WoodenSpoon_Hitbox" /* || any other weapon equipped?*/)
        {
            isHit = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Explode();
            isActive = false;
        }
    }

}
