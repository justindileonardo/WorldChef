using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic_Italy : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject enemyBreadPrefab;
    public GameObject enemyMeatballPrefab;

    // Use this for initialization
    void Start ()
    {
        SpawnEnemies1();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SpawnEnemies1()
    {
        Instantiate(enemyBreadPrefab, new Vector3(25f, -7.15f, 0), Quaternion.identity);
        Instantiate(enemyBreadPrefab, new Vector3(50f, -7.15f, 0), Quaternion.identity);
    }




}
