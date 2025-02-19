using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamePiece[] pieces;

    private void Start()
    {
        pieces = GetComponentsInChildren<GamePiece>(); // Finder brikker under spilleren
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position == 0)
                {
                    pieces[i].Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position + rollValue <= 40)
                {
                    pieces[i].Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].Position < 40)
            {
                pieces[i].Move(rollValue);
                return false;
            }
        }
        return true;
    }
}
