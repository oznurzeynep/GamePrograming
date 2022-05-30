using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingTime : MonoBehaviour
{
    public float minutes, seconds;
    public Text timeText;
    public Text timesUp;
    public UIGameOver player;
    public bool locked = true;

    void Start()
    {
        minutes = 1;
        seconds = 59;
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        timeText.text = "" + minutes + ":" + (int)seconds;
        if (seconds <= 0)
        {
            minutes--;
            seconds = 59;
        }
        if (minutes < 0)
        {
            Time.timeScale = 0;
            player.GameOver.SetActive(true);
            timesUp.text = "Time's Up";
        }
        if (minutes < 0)
        {
            if (locked == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }

            else
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
        }
    }
}
