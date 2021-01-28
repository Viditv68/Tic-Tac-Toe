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

    private int[] whichPlayerMarked;

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
            whichPlayerMarked[i] = -1;
        }


    }


    public void TicTacToeButton(int index)
    {
        ticTacToeSpaces[index].image.sprite = playIcons[whoseTurn];
        ticTacToeSpaces[index].interactable = false;

        whichPlayerMarked[index] = whoseTurn;
        turnCount++;

        if(whoseTurn == 0)
        {
            whoseTurn = 1;
        }
        else
        {
            whoseTurn = 0;
        }
    }
}
