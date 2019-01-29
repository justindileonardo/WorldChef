using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour {

    public GameObject player;
    public GameObject enemyBasicPrefab;
    public GameObject enemyI2Prefab;

    // Use this for initialization
    void Start() {
        Instantiate(enemyBasicPrefab, new Vector3(1f, -2.65f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(14.2f, -10.7f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(34.37f, 3.17f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(84.61f, 0.65f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

    }

    public void SpawnEnemyl2_1()
    {
        Instantiate(enemyI2Prefab, new Vector3(24.1f, -10.41f, 0), Quaternion.identity);
    }
    public void SpawnEnemyl2_2()
    {
        Instantiate(enemyI2Prefab, new Vector3(52.01f, 3.51f, 0), Quaternion.identity);
    }
    public void SpawnEnemyl2_3()
    {
        Instantiate(enemyI2Prefab, new Vector3(70.57f, -10.4f, 0), Quaternion.identity);
    }


}
