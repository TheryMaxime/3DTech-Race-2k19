using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class countDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    [SerializeField] Text countDownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    { 
        currentTime -= 1f * Time.deltaTime;
        if(currentTime > 1f)
        {
            countDownText.text = currentTime.ToString("0");
        }
        else countDownText.text = "Go !";

        if (currentTime < -1f)
        {
            countDownText.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleSceneAntoine", LoadSceneMode.Single);
        }



    }
}
