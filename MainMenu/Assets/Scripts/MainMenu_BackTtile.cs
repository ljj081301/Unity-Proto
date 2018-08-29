using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_BackTtile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        SceneManager.LoadScene(0);
    }

    public void Stage_1()
    {
        SceneManager.LoadScene(2);
    }
}
