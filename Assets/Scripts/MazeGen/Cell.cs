using UnityEngine;

namespace MazeGen
{
    public class Cell : MonoBehaviour
    {
        public GameObject WallLeft;
        public GameObject WallBottom;
        public GameObject wallLeftBorder;
        public GameObject wallBottomBorder;
        public GameObject Floor;
        public GameObject Treasure;
        public GameObject ExitPortal;
        public GameObject Coin;
        public GameObject[] CoinsArray;
        public GameObject CoinField;
    }
}