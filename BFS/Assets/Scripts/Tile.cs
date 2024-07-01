using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isCurrent = false;
    public bool isTarget = false;
    public bool isSelectable = false;
    public bool isWalkable = true;

    public bool isVisited = false;
    public Tile parent = null;
    public int distance = 0;

    public List<Tile> adjacentList = new List<Tile>();
    private void Update()
    {
        if (isCurrent)
        {
            GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Standing on current platform");
        }
        else if (isTarget)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log($"Found current platform target");
        }
        else if (isSelectable)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Platform is currently selectable");
        }
        else
        {
            GetComponent<Renderer>().material = Resources.Load<Material>("Tile");
        }
    }

    public void ResetValues()
    {
        adjacentList.Clear();
        isCurrent = false;
        isTarget = false;
        isSelectable = false;
        isVisited = false;
        parent = null;
        distance = 0;
    }

    public void FindNeighbors(float jumpHeight)
    {
        ResetValues();
        CheckTiles(Vector3.forward, jumpHeight);
        CheckTiles(Vector3.back, jumpHeight);
        CheckTiles(Vector3.right, jumpHeight);
        CheckTiles(Vector3.left, jumpHeight);
    }

    public void CheckTiles(Vector3 dir, float jumpHeight)
    {
        Vector3 halfExtents = new(0.25f, (1 + jumpHeight) / 2, 0.25f);
        Collider[] collider = Physics.OverlapBox(transform.position + dir, halfExtents);
        foreach (Collider col in collider)
        {
            Tile tile = col.GetComponent<Tile>();
            if (tile != null && tile.isWalkable)
            {
                RaycastHit hit;
                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    adjacentList.Add(tile);
                }
            }
        }
    }
}
