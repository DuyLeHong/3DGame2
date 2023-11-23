using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    public static float score = 0f;
    private int maxLevel = 10;
    private int level = 1;
    private int scoreToNextLevel = 3; // khoang cach diem giua cac level
    private bool isDead = false;

    internal void Dead ()
    {
        isDead = true;
    }

    public void TangDiem (float diem)
    {
        score += diem;
    }

    public void TangLevel ()
    {
        if (level == maxLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        ++level;
        // thay doi toc do - tham chieu player running
        GetComponent<PlayerRunning>().setSpeed(level);
    }



    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (score > scoreToNextLevel)
            {
                TangLevel();
            }
            scoreText.text = "Score: " + ((int)score).ToString();
            levelText.text = "Level: " + level.ToString();
        }
    }
}
