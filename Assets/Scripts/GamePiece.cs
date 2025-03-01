using UnityEngine;
using UnityEngine.UIElements;

public class GamePiece : MonoBehaviour
{

        private int position = 0; // Tilføjet position tracking

        public int Position { get => position; }

        public void Move(int x) //Implementeret Move metode
    {
            transform.position = transform.position + new Vector3(x * 2, 0, 0);
        }

}