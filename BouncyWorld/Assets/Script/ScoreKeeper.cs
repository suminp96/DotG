using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    private Text txt;
    private int score;
    private void Awake()
    {
        txt = GetComponentInChildren<Text>();
        ShowScore();
    }
    public void ShowScore()
    {
        txt.text = "Score: <color=red>"+score+"</color>";
    }
    public void AddScore(int s)
    {
        score += s;
        ShowScore();
    }
    public int GetScore()
    {
        return score;
    }
}
