using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamePiece[] pieces;

    private void Start()
    {
        pieces = GetComponentsInChildren<GamePiece>(); // Henter referencer til spillerens brikker ved at finde alle GamePiece-objekter under spilleren
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6) // Hvis spilleren slår en sekser, skal en brik sættes i spil
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x == 0) // Finder en brik, der stadig er i startpositionen (x == 0), og sætter den i spil
                {
                    pieces[i].GetComponent<MeshRenderer>().enabled = true; // Gør brikken synlig
                    pieces[i].GetComponent<GamePiece>().Move(1); // Flytter brikken ud på banen
                    return false; // Turen slutter
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x + rollValue <= 80 && pieces[i].transform.position.x > 0) // Flytter en brik fremad, hvis den ikke overskrider banegrænsen (x ≤ 80)
                {
                    pieces[i].GetComponent<GamePiece>().Move(rollValue);
                    return false; // Turen slutter
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++) // Hvis alle brikker har nået slutpositionen, returneres true for at signalere, at spilleren er færdig
        {
            if(pieces[i].transform.position.x < 80) 
            {
                return false;// Spilleren er ikke færdig endnu
            }
        }
        return true; // Spilleren har vundet
    }

}

