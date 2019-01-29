using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour {

	public EnemyBoss EnemyBossScript;
    public GameObject spitball;
    public GameObject straw;
    public float spitballShootTimer;

    public GameObject meatball;
    public GameObject meatballLauncher;
    public float meatballShootTimer;

    public BoxCollider2D attackBoxWoodenSpoon;
    public float woodenSpoonTimer;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (WeaponManager.w3 == true)
        {
            spitballShootTimer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && WeaponManager.w3 && spitballShootTimer > .75f)
        {
            Instantiate(spitball, straw.transform.position, Quaternion.identity);
            spitballShootTimer = 0;

        }

        if (WeaponManager.w4 == true)
        {
            meatballShootTimer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && WeaponManager.w4 && meatballShootTimer > 2f)
        {
            Instantiate(meatball, straw.transform.position, Quaternion.identity);
            meatballShootTimer = 0;

        }

        //new attacking
        woodenSpoonTimer += Time.deltaTime;
        if(woodenSpoonTimer > .5f)
        {
            attackBoxWoodenSpoon.enabled = false;
        }

        if(Input.GetMouseButtonDown(0) && woodenSpoonTimer > 1.5f)
        {
            if(WeaponManager.w2 == true)
            {
                woodenSpoonTimer = 0;
                attackBoxWoodenSpoon.enabled = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBasic")
        {
            if (other.gameObject.tag == "EnemyBasic")
            {
                EnemyBasic enemyBasicScript = other.gameObject.GetComponent<EnemyBasic>();

                if (WeaponManager.w1 == true)
                {
                    enemyBasicScript.HP -= 1;

                    print(enemyBasicScript.HP);
                }
                else if (WeaponManager.w2 == true)
                {
                    enemyBasicScript.HP -= .5f;
                    print(enemyBasicScript.HP);
                }
            }
        }

    }


    void OnTriggerStay2D(Collider2D other){



        /*if (Input.GetMouseButtonDown (0)) 
        {
		
			if (other.gameObject.tag == "EnemyBasic") 
            {
                EnemyBasic enemyBasicScript = other.gameObject.GetComponent<EnemyBasic>();


                if (WeaponManager.w1 == true)
                {
                    enemyBasicScript.HP -= 1;

                    print(enemyBasicScript.HP);
                }
                else if (WeaponManager.w2 == true)
                {
                    enemyBasicScript.HP -= .5f;
                    print(enemyBasicScript.HP);
                }
                

            }
			if (other.gameObject.tag == "EnemyI1") {
                EnemyI1 enemyI1Script = other.gameObject.GetComponent<EnemyI1>();
                if (WeaponManager.w1 == true)
                {
                    enemyI1Script.HP -= 1;
                }
                else if (WeaponManager.w2 == true)
                {
                    enemyI1Script.HP -= 1;
                }
            }
            if (other.gameObject.tag == "EnemyI2")
            {
                EnemyI2 enemyI2Script = other.gameObject.GetComponent<EnemyI2>();
                if (WeaponManager.w1 == true)
                {
                    enemyI2Script.HP -= 1;
                }
                else if (WeaponManager.w2 == true)
                {
                    enemyI2Script.HP -= 1;
                }
            }
            if (other.gameObject.tag == "EnemyBoss") {
                if (WeaponManager.w1 == true)
                {
                    EnemyBossScript.HP -= 1;
                }
                else if (WeaponManager.w2 == true)
                {
                    EnemyBossScript.HP -= 1;
                }
            }
		}*/
	}


}
