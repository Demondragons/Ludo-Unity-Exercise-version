using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameLogic : MonoBehaviour
{
    public Player[] players;    
    private int currentPlayer = 0;
    private bool gameActive = true;

    private void Start()
    {
        players = GetComponents<Player>(); // Finder alle spillere i scenen
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (gameActive)
        {
            int diceRoll = RollDice();
            bool winner = players[currentPlayer].DecideAndMovePiece(diceRoll);

            if (winner)
            {
                Debug.Log("Winner is player " + (currentPlayer + 1));
                gameActive = false;
            }

            yield return new WaitForSeconds(1f); // Gør hvert træk synligt

            currentPlayer = (currentPlayer + 1) % players.Length;
        }
    }

    private System.Random random = new System.Random();
    public int RollDice()
    {
        return random.Next(1, 7);
    }
}
