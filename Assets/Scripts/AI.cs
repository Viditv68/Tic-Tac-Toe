
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    private int move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.whoseTurn == 1)
        {

            move = FindBestMove();
            gameController.TicTacToeButton(move);


        }
    }

    private int FindBestMove()
    {
        List<int> available = new List<int>();

        for(int i = 0; i < gameController.ticTacToeSpaces.Length; i++)
        {
            if(gameController.ticTacToeSpaces[i].interactable)
            {
                available.Add(i);
            }
        }

        int random = Random.Range(0, available.Count);

        return available[random];
    }
}
