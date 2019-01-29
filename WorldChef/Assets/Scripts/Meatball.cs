using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour {

    public float moveSpeed;
    public float theDirection;

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMeatball", 2.5f);

        if (PlayerMovement.direction == 1)
        {
            theDirection = 1;
        }
        if (PlayerMovement.direction == 2)
        {
            theDirection = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (theDirection == 1)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (theDirection == 2)
        {
            transform.position += -Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    void DestroyMeatball()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyBasic")
        {
            EnemyBasic enemyBasicScript = other.gameObject.GetComponent<EnemyBasic>();
            enemyBasicScript.HP -= 2f;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "EnemyI1")
        {
            EnemyI1 enemyI1Script = other.gameObject.GetComponent<EnemyI1>();
            enemyI1Script.HP -= 2f;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "EnemyBoss")
        {
            EnemyBoss enemyBossScript = other.gameObject.GetComponent<EnemyBoss>();
            enemyBossScript.HP -= 2f;
            Destroy(gameObject);
        }
    }
}
