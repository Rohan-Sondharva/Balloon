using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreIncreasePerSecond = 1f;
    float score = 0;
    int scoreInInt;


    // Update is called once per frame
    void Update()
    {
        scoreInInt = (int)Math.Round(score);
        scoreText.text = scoreInInt.ToString();
        score += scoreIncreasePerSecond * Time.deltaTime;
    }
}
