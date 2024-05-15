using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int score;

    [SerializeField] private Text display;

    public void UpdateScore(int addPoints)
    {
        score += addPoints;
        display.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            UpdateScore(20);
            Debug.Log("aaaaaa");
        }
    }
}
