using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float timer;
    public float TimerInterval = 5f;
    float tick;
    

    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimerText.text = (int)timer / 60 + " : " + (int)timer % 60;
    }
    
}