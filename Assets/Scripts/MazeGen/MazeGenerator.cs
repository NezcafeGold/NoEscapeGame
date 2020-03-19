using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellObj
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Floor = true;
    public bool Visited = false;
    public bool Treasure = false;
    public bool Coin = false;
    public bool WallLeftBorder = false;
    public bool WallBottomBorder = false;
    public bool Exit = false;
}

public class MazeGenerator
{
    private readonly int Width;
    private readonly int Height;
    private readonly int ChangeOfTreasure;
    

    public MazeGenerator(int width, int height, int changeOfTreasure)
    {
        Width = width;
        Height = height;
        ChangeOfTreasure = changeOfTreasure;
    }

    public CellObj[,] GenerateMaze()
    {
        var maze = new CellObj[Width, Height];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new CellObj {X = x, Y = y};
                if (x + 1 == maze.GetLength(0))
                {
                    maze[x, y].WallBottom = false;
                    maze[x, y].Floor = false;
                    maze[x, y].WallLeftBorder = true;
                    maze[x, y].WallLeft = false;
                }

                if (y + 1 == maze.GetLength(1))
                {
                    maze[x, y].WallLeft = false;
                    maze[x, y].Floor = false;
                    maze[x, y].WallBottomBorder = true;
                    maze[x, y].WallBottom = false;
                }

                if (x == 0)
                {
                    maze[x, y].WallLeftBorder = true;
                    maze[x, y].WallLeft = false;
                }

                if (y == 0)
                {
                    maze[x, y].WallBottomBorder = true;
                    maze[x, y].WallBottom = false;

                }
            }
        }

        RemoveWalls(maze);
        PlaceItems(maze);
        PlaceExit(maze);
        return maze;
    }

    private void PlaceExit(CellObj[,] maze)
    {
        //TODO: check if exit with other objects
        var dir = Random.Range(0, 3);
        switch (dir)
        {
            case 0:
                maze[0, Random.Range(0, Height - 2)].Exit = true;
                break;
            case 1:
                maze[Width - 2, Random.Range(0, Height - 2)].Exit = true;
                break;
            case 2:
                maze[Random.Range(0, Width - 2), 0].Exit = true;
                break;
            case 3:
                maze[Random.Range(0, Width - 2), Height - 2].Exit = true;
                break;
        }
    }

    private void PlaceItems(CellObj[,] maze)
    {
        /**
         * Hardcode for Tresure in [0,0]
         */
        //maze[0, 0].Treasure = true;

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y].Treasure = isNeedTreasure(maze, x, y);
            }
        }
    }

    private bool isNeedTreasure(CellObj[,] maze, int x, int y)
    {
        var count = 0;
        if (maze[x, y].WallLeft) count++;
        if (maze[x, y].WallBottom) count++;
        if (x + 1 != maze.GetLength(0))
            if (maze[x + 1, y].WallLeft)
                count++;
        if (y + 1 != maze.GetLength(1))
            if (maze[x, y + 1].WallBottom)
                count++;
        if (count == 3 && Random.Range(0, 100) < ChangeOfTreasure)
        {
            return true;
        }
        return false;
    }
    

    private void RemoveWalls(CellObj[,] maze)
    {
        CellObj current = maze[0, 0];
        current.Visited = true;
        Stack<CellObj> stack = new Stack<CellObj>();
        do
        {
            List<CellObj> unvisited = new List<CellObj>();
            if (current.X > 0 && !maze[current.X - 1, current.Y].Visited) unvisited.Add(maze[current.X - 1, current.Y]);
            if (current.Y > 0 && !maze[current.X, current.Y - 1].Visited) unvisited.Add(maze[current.X, current.Y - 1]);
            if (current.X < Width - 2 && !maze[current.X + 1, current.Y].Visited)
                unvisited.Add(maze[current.X + 1, current.Y]);
            if (current.Y < Height - 2 && !maze[current.X, current.Y + 1].Visited)
                unvisited.Add(maze[current.X, current.Y + 1]);

            if (unvisited.Count > 0)
            {
                CellObj chosen = unvisited[Random.Range(0, unvisited.Count)];
                RemoveWall(current, chosen);
                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);

        RemoveRandomWalls(maze);
    }

    private void RemoveRandomWalls(CellObj[,] maze)
    {
        for (int i = 0; i < Width/2; i++)
        {
            if(Random.Range(0,1)==1)
            maze[Random.Range(1, Width - 1), Random.Range(1, Height - 1)].WallLeft = false;
            else
            maze[Random.Range(1, Width - 1), Random.Range(1, Height - 1)].WallBottom = false;
        }
    }

    private void RemoveWall(CellObj current, CellObj chosen)
    {
        if (current.X == chosen.X)
        {
            if (current.Y > chosen.Y) current.WallBottom = false;
            else chosen.WallBottom = false;
        }
        else
        {
            if (current.X > chosen.X) current.WallLeft = false;
            else chosen.WallLeft = false;
        }
    }
}