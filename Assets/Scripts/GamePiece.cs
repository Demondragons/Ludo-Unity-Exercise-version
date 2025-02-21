using UnityEngine;

public class GamePiece : MonoBehaviour
{

        private int position = 0;

        public int Position { get => position; }

        public void Move(int x)
        {
            position += x;
        }

}