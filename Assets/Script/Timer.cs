using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float time;
    public float TimerInterval = 5f;
    float tick;

    // Use this for initialization
    void Awake()
    {
        time = (int)Time.time;
        tick = TimerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
        time = (int)Time.time;

        if (time == tick)
        {
            tick = time + TimerInterval;
            Debug.Log("Timer");
        }
    }

    void TimerExecute()
    {
        Debug.Log("Timer");
    }
}