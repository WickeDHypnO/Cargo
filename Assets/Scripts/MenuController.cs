using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject startMenu;
    public GameObject endMenu;

    void OnEnable()
    {
        GameManager.i.menu = this;
    }

    public void GoBackToMenu()
    {
        GameManager.i.state = GameManager.GameState.Menu;
        SceneManager.LoadScene(0);
    }
	// Use this for initialization
}
