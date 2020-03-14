using MazeGen;
using MazeGen.Util;
using UnityEngine;

public class   MazeSpawn : MonoBehaviour
{

    public GameObject CellPrefab;
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
        
      MazeGenerator generator = new MazeGenerator(gC.XSize, gC.YSize, gC.ChangeOfTreasure);
        CellObj[,] maze = generator.GenerateMaze();
        
        for(int x = 0; x<maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector2(x * size, y * size), Quaternion.identity)
                    .GetComponent<MazeGen.Cell>();
                c.WallLeft.SetActive(maze[x,y].WallLeft);
                c.WallBottom.SetActive(maze[x,y].WallBottom);
                c.Floor.SetActive(maze[x,y].Floor);
                c.Treasure.SetActive(maze[x,y].Treasure);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Size => size;
}
