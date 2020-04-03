using MazeGen;
using MazeGen.Util;
using UnityEngine;

public class MazeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject CellPrefab;
    [SerializeField] private GameController gC;
    private float size;

    void Awake()
    {
        var bounds = CellPrefab.GetComponent<SpriteRenderer>().bounds;
        size = Mathf.Abs(bounds.max.x - bounds.min.x);
        gC.SizeOfCeil = size;
    }

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator generator = new MazeGenerator(gC.XSize, gC.YSize, gC.ChangeOfTreasure, gC.MaxCoins, gC.ChangeOfCoins);
        CellObj[,] maze = generator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector2(x * size, y * size), Quaternion.identity)
                        .GetComponent<MazeGen.Cell>();
                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);
                c.wallLeftBorder.SetActive(maze[x,y].WallLeftBorder);
                c.wallBottomBorder.SetActive(maze[x,y].WallBottomBorder);
                c.Floor.SetActive(maze[x, y].Floor);
                c.Treasure.SetActive(maze[x, y].Treasure);
                c.ExitPortal.SetActive(maze[x,y].Exit);
                if (maze[x, y].CoinCount > 0)
                {
                    c = generateCoins(maze[x,y], c);
                }
            }
        }
    }

    private Cell generateCoins(CellObj maze, Cell c)
    {
        var x = c.CoinField.transform.position.x;
        var y = c.CoinField.transform.position.y;
        var xn = c.CoinField.transform.localScale.x + x;
        var yn = c.CoinField.transform.localScale.y + y;
        c.CoinsArray = new GameObject[maze.CoinCount];
        for (int i = 0; i < maze.CoinCount; i++)
        {

            var rx = Random.Range(x, xn);
            var ry = Random.Range(y, yn);
            GameObject coin = Instantiate(c.Coin, new Vector2(rx, ry), Quaternion.identity);
            coin.SetActive(true);
            c.CoinsArray[i] = coin;
        }

        return c;
    }

    // Update is called once per frame
    void Update()
    {
    }
}