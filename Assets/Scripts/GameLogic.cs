using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Player[] players = new Player[4];
    private int currentPlayer = 0;
    private bool gameActive = true; 

    private void Start()
    {
        players = Object.FindObjectsByType<Player>(FindObjectsSortMode.InstanceID); // Finder alle spillere i scenen
        if (players.Length == 0)
        {
            Debug.LogError("No players found in the scene!");
            return;
        }
        StartCoroutine(GameLoop());
    }
    int winnerFound = -1;
    Dice dice = new Dice();
    //While (winnerFound < 0)
    //{
    //    for (int i = 0; i < players.Length; i++)
    //    {
    //        int diceRoll = dice.RollDice();
    //        bool winner = players[i].DecideAndMovePiece(diceRoll);
    //        if (winner)
    //        {
    //            winnerFound = i;
    //            break;
    //        }
    //    }
    //}

    private IEnumerator GameLoop()
    {
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                int diceRoll = dice.RollDice();
                bool winner = players[currentPlayer].DecideAndMovePiece(diceRoll);

                if (winner)
                {
                    Debug.Log("Winner is player " + (currentPlayer + 1));
                    gameActive = false;
                    winnerFound = i;
                    yield break; // Stopper coroutine
                }

                yield return new WaitForSeconds(0.1f); // Gør hvert træk synligt
            }

        }
    }
    public class Dice
    {
        public int RollDice()
        {
            return Random.Range(1, 7);
        }
    }
    //private Random random = new Random();
    //public int RollDice()
    //{
    //    return Random.Range(1, 7); // Unitys Random-funktion
    //}
}
