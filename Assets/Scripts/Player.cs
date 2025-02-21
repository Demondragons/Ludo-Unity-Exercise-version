using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamePiece[] pieces;

    private void Start()
    {
        pieces = GetComponentsInChildren<GamePiece>(); // Finder brikker under spilleren
        gameObject.SetActive(false);
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position == 0)
                {
                    gameObject.SetActive(true);
                    pieces[i].Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position + rollValue <= 4000)
                {
                    pieces[i].Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].Position < 4000)
            {
                pieces[i].Move(rollValue);
                return false;
            }
        }
        return true;
    }

}
//GameObject.FindGameObjectWithTag("Player".FindSortMode.Instance
