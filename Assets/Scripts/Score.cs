using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreClass
{
    public int highScore;
}

public class Score : MonoBehaviour
{
    private int currentScore = 0;
    private int highestScore = 0;

    string fileName = "/Score.txt";

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
        HighScoreClass s = new HighScoreClass();
        s.highScore = highestScore;
        string json = JsonUtility.ToJson(s);
        File.WriteAllText(Application.dataPath + fileName, json);
        Debug.Log(json);
    }

    public int GetHighScore()
    {
        if(File.Exists(Application.dataPath + fileName))
        {
            string saveString = File.ReadAllText(Application.dataPath + fileName);

            HighScoreClass s = JsonUtility.FromJson<HighScoreClass>(saveString);

            return s.highScore;

        }
        return 0;
    }

    
}



