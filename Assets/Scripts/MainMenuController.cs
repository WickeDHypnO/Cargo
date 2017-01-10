using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour {
    public List<Button> levelButtons;
	// Use this for initialization

	
	// Update is called once per frame
	public void LoadLevel (string name) {
        SceneManager.LoadScene(name);
	}
}
