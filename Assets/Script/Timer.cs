using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float timer = 0;
   // float time;
    public float TimerInterval = 5f;
    float tick;
    private int lvl;
    public Text timertext;
    

    /*void Awake()
    {
        lvl = SceneManager.GetActiveScene().buildIndex;
        //if (lvl == 2)
        {
            time = (int)Time.time;
            tick = TimerInterval;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        lvl = SceneManager.GetActiveScene().buildIndex;
        //if (lvl == 2)
        {
            timertext.name = timer + "";
                //string.Format("{0:0}:{1:00}", Mathf.Floor(timer / 60), timer % 60);
            timer += Time.deltaTime;
            Debug.Log(timer);
           // GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
           // time = (int)Time.time;

            /*if (time == tick)
            {
                tick = time + TimerInterval;
                Debug.Log("Timer");
            }
            */
        }
    }
    
}
