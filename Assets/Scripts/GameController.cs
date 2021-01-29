using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whoseTurn;
    public int turnCount;
    public Sprite[] playIcons;
    public Button[] ticTacToeSpaces;

    public bool gamefinished = false;

    [SerializeField]
    private int[] whichPlayerMarked;
    [SerializeField]
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    private void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;

        for(int i = 0; i < ticTacToeSpaces.Length; i++)
        {
            ticTacToeSpaces[i].interactable = true;
            ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
            whichPlayerMarked[i] = -100;
        }

        
    }


    public void TicTacToeButton(int index)
    {
        ticTacToeSpaces[index].image.sprite = playIcons[whoseTurn];
        ticTacToeSpaces[index].interactable = false;

        whichPlayerMarked[index] = whoseTurn+1;

        turnCount++;
        if(turnCount > 4)
        {
            CheckWinner();
        }

        if(turnCount >=9)
        {
            GameSetup();
        }

        if(whoseTurn == 0)
        {
            whoseTurn = 1;
        }
        else
        {
            whoseTurn = 0;
        }

    }

    public void CheckWinner()
    {
        float s1 = whichPlayerMarked[0] + whichPlayerMarked[1] + whichPlayerMarked[2];
        float s2 = whichPlayerMarked[3] + whichPlayerMarked[4] + whichPlayerMarked[5];
        float s3 = whichPlayerMarked[6] + whichPlayerMarked[7] + whichPlayerMarked[8];
        float s4 = whichPlayerMarked[0] + whichPlayerMarked[3] + whichPlayerMarked[6];
        float s5 = whichPlayerMarked[1] + whichPlayerMarked[4] + whichPlayerMarked[7];
        float s6 = whichPlayerMarked[2] + whichPlayerMarked[5] + whichPlayerMarked[8];
        float s7 = whichPlayerMarked[0] + whichPlayerMarked[4] + whichPlayerMarked[8];
        float s8 = whichPlayerMarked[0] + whichPlayerMarked[1] + whichPlayerMarked[6];

        var solutions = new float[] { s1, s2, s3, s4, s5, s6, s7, s8 };

        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (whoseTurn+1))
            {
                Debug.Log("player" + whoseTurn + "wins");
                if(whoseTurn == 0)
                {
                    score.IncrementScore();
                }
                GameSetup();
                return;
            }
        }

       

    }
}
