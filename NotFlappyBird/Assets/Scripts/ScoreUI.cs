using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreTxt;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "0";
        score = 0;
        scoreTxt.text = score.ToString();
    }

    public void UpdateScore() {
        score++;
        scoreTxt.text = score.ToString();

        if (score % 3 == 0) {
            Time.timeScale = Time.timeScale * 1.1f;
        }
    }
}
