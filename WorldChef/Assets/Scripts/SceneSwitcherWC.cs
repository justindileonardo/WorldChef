using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherWC : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
   
	}

    public void MenuToGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GameToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
