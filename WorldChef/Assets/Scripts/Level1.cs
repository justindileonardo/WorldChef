using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour {

    public GameObject player;
    public GameObject enemyBasicPrefab;
    public GameObject enemyI1Prefab;

    public TextMesh chooseWeapon;
    public TextMesh chooseWeapon1;
    public TextMesh chooseWeapon1Press;
    public TextMesh chooseWeapon2;
    public TextMesh chooseWeapon2Press;

    public static bool selectedWeapon1;
    public static bool selectedWeapon2;


    // Use this for initialization
    void Start() {
        Instantiate(enemyBasicPrefab, new Vector3(9f, -2.65f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(18.5f, 7.05f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(5.6f, 30.34f, 0), Quaternion.identity);
        Instantiate(enemyBasicPrefab, new Vector3(58f, 12.9f, 0), Quaternion.identity);

        chooseWeapon.GetComponent<MeshRenderer>().enabled = false;
        chooseWeapon1.GetComponent<MeshRenderer>().enabled = false;
        chooseWeapon1Press.GetComponent<MeshRenderer>().enabled = false;
        chooseWeapon2.GetComponent<MeshRenderer>().enabled = false;
        chooseWeapon2Press.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update() {

        if (EnemyBoss.bossDead)
        {
            chooseWeapon.GetComponent<MeshRenderer>().enabled = true;
            chooseWeapon1.GetComponent<MeshRenderer>().enabled = true;
            chooseWeapon1Press.GetComponent<MeshRenderer>().enabled = true;
            chooseWeapon2.GetComponent<MeshRenderer>().enabled = true;
            chooseWeapon2Press.GetComponent<MeshRenderer>().enabled = true;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon1 = true;
                print("Selected weapon 1");
                //load scene 2
                //SceneManager.LoadScene("Level2");
                SceneManager.LoadScene("Menu");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedWeapon2 = true;
                print("Selected weapon 2");
                //load scene 2
                //SceneManager.LoadScene("Level2");
                SceneManager.LoadScene("Menu");
            }

        }


    }

    public void SpawnEnemyl1_1()
    {
        Instantiate(enemyI1Prefab, new Vector3(37.5f, -1.26f, 0), Quaternion.identity);
    }
    public void SpawnEnemyl1_2()
    {
        Instantiate(enemyI1Prefab, new Vector3(-17.3f, 19f, 0), Quaternion.identity);
    }
    public void SpawnEnemyl1_3()
    {
        Instantiate(enemyI1Prefab, new Vector3(44.5f, 30.34f, 0), Quaternion.identity);
    }


}
