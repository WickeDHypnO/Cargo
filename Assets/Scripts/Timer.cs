using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerLabel;
    public bool counting;

    private float time;

    void Update()
    {
        if (counting)
        {
            time += Time.deltaTime;

            int minutes = (int)time / 60; //Divide the guiTime by sixty to get the minutes.
            int seconds = (int)time % 60;//Use the euclidean division for the seconds.
            float fraction = (time * 100) % 100;

            //update the label value
            timerLabel.text = string.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, fraction);
        }
    }

    public void StartCounting()
    {
        counting = true;
        GameManager.i.state = GameManager.GameState.Game;
    }

    public void StopCounting()
    {
        counting = false;
    }
}