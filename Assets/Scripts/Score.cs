using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveHighScore
{
    public int highScore;
}

public class Score : MonoBehaviour
{
    private int currentScore = 0;
    private int highestScore = 0;

    public void IncrementScore()
    {
        currentScore++;

        if (currentScore > GetHighScore())
        {
            highestScore = currentScore;
            SaveHighScoreinJson();
           
        }

        
    }

    private void SaveHighScoreinJson()
    {
        SaveHighScore s = new SaveHighScore();
        s.highScore = highestScore;
        string json = JsonUtility.ToJson(s);
        File.WriteAllText(Application.dataPath + "/saveScore.txt", json);
        Debug.Log(json);
    }

    public int GetHighScore()
    {
        if(File.Exists(Application.dataPath + "/saveScore.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/saveScore.txt");

            SaveHighScore s = JsonUtility.FromJson<SaveHighScore>(saveString);

            return s.highScore;

        }
        return 0;
    }

    
}



