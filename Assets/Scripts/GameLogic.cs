using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    public Player[] players = new Player[4]; // Array til at holde styr på spillerne

    private void Start()
    {   
        players = Object.FindObjectsByType<Player>(FindObjectsSortMode.InstanceID); // Finder alle spillere i scenen
        if (players.Length == 0)
        {
            Debug.LogError("No players found in the scene!"); // Fejlmeddelelse, hvis ingen spillere findes
            return;
        }
        StartCoroutine(GameLoop()); // Starter spillets hoved-loop som en coroutine
    }
    int winnerFound = -1; // Variabel til at holde styr på vinderen
    Dice dice = new Dice();

    private IEnumerator GameLoop()
    {
        while (winnerFound < 0) // Spillet fortsætter, indtil en spiller har vundet
        {
            for (int i = 0; i < players.Length; i++) // Gennemgår alle spillere
            {
                int diceRoll = dice.RollDice(); // Spilleren ruller en terning
                Debug.Log("Player " + (i + 1) + " rolled: " + diceRoll); // Debug output for dice roll
                bool winner = players[i].DecideAndMovePiece(diceRoll); // Spilleren forsøger at flytte en brik

                if (winner)
                {
                    Debug.Log("Winner is player " + (i + 1)); 
                    winnerFound = i;
                    yield break; // Stopper coroutine
                }

                yield return new WaitForSeconds(0.2f); // Gør hvert træk synligt
            }

        }
    }
    public class Dice
    {
        public int RollDice()
        {
            return Random.Range(1, 7); // Returnerer et tilfældigt tal mellem 1 og 6
        }
    }
}
