using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    List<Checkpoint> Checkpoints = new List<Checkpoint>();
    public LevelManager levelManager;
    public CarController car;
    public MenuController menu;
    public GameState state;
    // Use this for initialization
    public enum GameState
    {
        Menu,
        Game,
        End
    }

    public static GameManager i;

    void Awake()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void OnEnable()
    {
        state = GameState.Menu;
        car = FindObjectOfType<CarController>();
        menu = FindObjectOfType<MenuController>();
    }

    void OnLevelWasLoaded()
    {

        levelManager = FindObjectOfType<LevelManager>();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Checkpoints.Clear();
            Checkpoints = levelManager.checkpoints;
        }
        car = FindObjectOfType<CarController>();
    }

    public void LevelEnd()
    {
        FindObjectOfType<Timer>().StopCounting();
        FindObjectOfType<CarUserControl>().enabled = false;
        state = GameState.End;
        menu.endMenu.SetActive(true);
        //SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if(state == GameState.End)
        {
            if(car.CurrentSpeed <= 1f)
                car.Move(0, 0, 1f, 1f);
            else
                car.Move(0, -1f, 1f, 1f);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
