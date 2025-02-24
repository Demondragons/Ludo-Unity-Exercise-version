using UnityEngine;
using UnityEngine.UIElements;

public class GamePiece : MonoBehaviour
{

        private int position = 0;

        public int Position { get => position; }

        public void Move(int x)
        {
            transform.position = transform.position + new Vector3(x * 2, 0, 0);
        }

}