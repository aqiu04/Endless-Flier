using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int score;
    private static double realScore = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControl.gameActive) {
            realScore += Time.deltaTime * 10;
            score = (int)(realScore);
            scoreText.text = "Score: " + score;
        }
    }

    public static void AddScore(int pointValue) {
        realScore += pointValue;
    }

    public static void SetScore(int pointValue) {
        realScore = pointValue;
    }
}
 