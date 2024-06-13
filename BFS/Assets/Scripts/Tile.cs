using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition;
    public List<Tile> neighbors;

    void Update()
    {
        BFS();
    }

    void BFS()
    {
        Queue<Tile> queue = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();

        queue.Enqueue(this);
        visited.Add(this);

        while (queue.Count > 0)
        {
            Tile tile = queue.Dequeue();
            Debug.Log("Visiting Tile at Position " + tile.gridPosition);

            foreach (Tile neighbor in tile.neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
