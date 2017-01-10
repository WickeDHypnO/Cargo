using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    
    private bool levelEnded;

    public bool LevelEnded
    {
        get
        {
            return levelEnded;
        }
        set
        {
            levelEnded = value;
            //End Of level screeeeeeen
            GameManager.i.LevelEnd();
        }
    }
	// Use this for initialization
	void Start () {
	    foreach(Checkpoint c in checkpoints)
        {
            c.levelManager = this;
        }
	}
	
	// Update is called once per frame
	void OnEnable () {
        GameManager.i.levelManager = this;
	}
}
