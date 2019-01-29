using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public static bool w1, w2, w3, w4;
    public GameObject weapon1, weapon2, weapon3, weapon4, attackBox1, attackBox2, attackBox3, attackBox4;
    public bool lowWeapons, highWeapons;

    // Use this for initialization
    void Start()
    {
        w1 = false;
        w2 = true;
        w3 = false;
        w4 = false;
        lowWeapons = true;
        highWeapons = false;
    }

    // Update is called once per frame
    void Update()
    {
        //switches modes
        /*if(Input.GetKeyDown(KeyCode.P))
        {
            highWeapons = !highWeapons;
            lowWeapons = !lowWeapons;
            w4 = false;
            weapon4.gameObject.SetActive(false);
            attackBox4.gameObject.SetActive(false);
            w3 = false;
            weapon3.gameObject.SetActive(false);
            attackBox3.gameObject.SetActive(false);
            w1 = false;
            weapon1.gameObject.SetActive(false);
            attackBox1.gameObject.SetActive(false);
            w2 = true;
            weapon2.gameObject.SetActive(true);
            attackBox2.gameObject.SetActive(true);
        }*/


        if (highWeapons)
        {
            if (Input.GetKeyDown(KeyCode.E) && w1)
            {
                w1 = false;
                w2 = true;
            }
            /*else if (Input.GetKeyDown(KeyCode.E) && w2)
            {
                w2 = false;
                w3 = true;
            }*/

            else if (Input.GetKeyDown(KeyCode.E) && w2)
            {
                w2 = false;
                w1 = true;
            }

            /*else if (Input.GetKeyDown(KeyCode.E) && w3)
            {
                w3 = false;
                w4 = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && w4)
            {
                w4 = false;
                w1 = true;
            }*/


            if (w1)
            {
                weapon1.gameObject.SetActive(true);
                attackBox1.gameObject.SetActive(true);
            }
            else
            {
                weapon1.gameObject.SetActive(false);
                attackBox1.gameObject.SetActive(false);
            }

            if (w2)
            {
                weapon2.gameObject.SetActive(true);
                attackBox2.gameObject.SetActive(true);
            }
            else
            {
                weapon2.gameObject.SetActive(false);
                attackBox2.gameObject.SetActive(false);
            }

            if (w3)
            {
                weapon3.gameObject.SetActive(true);
                attackBox3.gameObject.SetActive(true);
            }
            else
            {
                weapon3.gameObject.SetActive(false);
                attackBox3.gameObject.SetActive(false);
            }
            if (w4)
            {
                weapon4.gameObject.SetActive(true);
                attackBox4.gameObject.SetActive(true);
            }
            else
            {
                weapon4.gameObject.SetActive(false);
                attackBox4.gameObject.SetActive(false);
            }
        }


        if(lowWeapons)
        {
            if (Level1.selectedWeapon1)
            {
                if (Input.GetKeyDown(KeyCode.E) && w2)
                {
                    w2 = false;
                    w1 = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) && w1)
                {
                    w1 = false;
                    w2 = true;
                }
            } 
            else if (Level1.selectedWeapon2)
            {
                if (Input.GetKeyDown(KeyCode.E) && w2)
                {
                    w2 = false;
                    w3 = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) && w3)
                {
                    w3 = false;
                    w2 = true;
                }
            }
            /*if (Input.GetKeyDown(KeyCode.E) && w2)
            {
                w2 = false;
                w3 = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && w3)
            {
                w3 = false;
                w2 = true;
            }*/

            if (w1)
            {
                weapon1.gameObject.SetActive(true);
                attackBox1.gameObject.SetActive(true);
            }
            else
            {
                weapon1.gameObject.SetActive(false);
                attackBox1.gameObject.SetActive(false);
            }
            if (w2)
            {
                weapon2.gameObject.SetActive(true);
                //attackBox2.gameObject.SetActive(true);
            }
            else
            {
                weapon2.gameObject.SetActive(false);
                //attackBox2.gameObject.SetActive(false);
            }

            if (w3)
            {
                weapon3.gameObject.SetActive(true);
                attackBox3.gameObject.SetActive(true);
            }
            else
            {
                weapon3.gameObject.SetActive(false);
                attackBox3.gameObject.SetActive(false);
            }


        }


    }
}
