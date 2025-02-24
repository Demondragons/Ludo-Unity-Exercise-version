using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamePiece[] pieces;

    private void Start()
    {
        pieces = GetComponentsInChildren<GamePiece>(); // Finder brikker under spilleren
        //gameObject.SetActive(true);
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x == 0)
                {
                    pieces[i].GetComponent<MeshRenderer>().enabled = true;
                    pieces[i].GetComponent<GamePiece>().Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x + rollValue <= 80)
                {
                    pieces[i].GetComponent<GamePiece>().Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].transform.position.x < 80)
            {
                pieces[i].GetComponent<GamePiece>().Move(rollValue);
                return false;
            }
        }
        return true;
    }

}
//GameObject.FindGameObjectWithTag("Player".FindSortMode.Instance
