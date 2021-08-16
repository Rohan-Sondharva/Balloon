using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    // Config Params
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreIncreasePerSecond;
    [SerializeField] float minScoreIncreasePerSecond = 1f;
    [SerializeField] float maxScoreIncreasePerSecond = 10f;

    float score = 0;
    float secToMaxIncreasePerSec = 60f;
    int scoreInInt;


    // Update is called once per frame
    void Update()
    {
        IncreasingScorePerSecond();
    }

    void IncreasingScorePerSecond()
    {
        scoreInInt = (int)Math.Round(score);
        scoreText.text = scoreInInt.ToString();
        scoreIncreasePerSecond = Mathf.Lerp(minScoreIncreasePerSecond, maxScoreIncreasePerSecond, GetScorePercent());
        score += scoreIncreasePerSecond * Time.deltaTime;
    }

    public void AddToScore(int scoreAmount)
    {
        score += scoreAmount;
    }

    float GetScorePercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secToMaxIncreasePerSec);
    }

}
