﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerClock : MonoBehaviour
{
    // Time in float to be converted to clock time
    public float timer;
    // Displaying clock time
    public string clockTime;
    // How the font looks
    public GUIStyle text;

    public DateTime time;

    void Update()
    {
        time = DateTime.Now;
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
            }
        }
    }
    private void OnGUI()
    {
        //int thousand = Mathf.FloorToInt(timer / 100);
        //int hundread = Mathf.FloorToInt(timer - thousand * 10);
        //clockTime = string.Format("{0:0}:{1:00}", thousand, hundread);

        //.Label(new Rect(10,10,250,100), clockTime, text);

        int mins = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - mins * 60);
        clockTime = string.Format("{0:0}:{1:00}", mins, seconds);

        GUI.Label(new Rect(10, 10, 250, 100), clockTime, text);
        GUI.Label(new Rect(10, 200, 250, 100), time.Hour +":"+ time.Minute +":"+ time.Second, text);
    }
}
