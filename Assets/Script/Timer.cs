using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float time;
    public float TimerInterval = 5f;
    float tick;
    

    void Awake()
    {
        string scene;
        scene = SceneManagerHelper.ActiveSceneName;
        if (scene != "Menu")
        {
            time = (int)Time.time;
            tick = TimerInterval;
        }
        Debug.Log(scene + "1" + time);
    }

    // Update is called once per frame
    void Update()
    {
        string scene;
        scene = SceneManagerHelper.ActiveSceneName;
        if (scene != "Menu")
        {
            GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
            time = (int)Time.time;

            if (time == tick)
            {
                tick = time + TimerInterval;
                Debug.Log("Timer");
            }
        }
        Debug.Log(scene + "2" + time);
    }

    void TimerExecute()
    {
        Debug.Log("Timer");
    }
}