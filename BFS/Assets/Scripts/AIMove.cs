using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    List<Tile> selectableTiles = new();
    GameObject[] tiles;
    Stack<Tile> path = new();
    Tile currentTile;
    public int move = 5;
    public float jumpHeight = 2;
    public float moveSpeed;

    public bool isMoving;
    Vector3 velocity = new();
    Vector3 heading = new();

    float halfHeight = 0;
    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        halfHeight = GetComponent<Collider>().bounds.extents.y;
    }
    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.isCurrent = true;
    }
    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;
        if (Physics.Raycast(target.transform.position, Vector3.down, out hit, 1))
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }
    public void ComputeAdjacentList()
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(jumpHeight);
        }
    }
    public void FindSelectableTIles()
    {
        ComputeAdjacentList();
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
        process.Enqueue(currentTile);
        currentTile.isVisited = true;
        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            selectableTiles.Add(t);
            t.isSelectable = true;
            if (t.distance < move)
            {
                foreach (Tile tile in t.adjacentList)
                {
                    if (!tile.isVisited)
                    {
                        tile.parent = t;
                        tile.isVisited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }
}
