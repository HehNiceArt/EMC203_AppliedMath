using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject prefab;
    public GameObject tiles;
    public void GenerateGrid()
    {
        if(prefab == null)
        {
            Debug.LogError("NO PREFAB FOUND!"); 
        }
        ClearGrid();
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x, 0, y);
                GameObject obj = Instantiate(prefab, Vector3.zero, transform.rotation);
                obj.transform.position = pos;
                obj.transform.parent = tiles.transform;
                obj.tag = "Tile";
            }
        }
    }
    public void ClearGrid()
    {
        GameObject[] destroyObj;
        destroyObj = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject obj in destroyObj)
        {
            DestroyImmediate(obj);
        }
    }
    public void AssignMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material mat = Resources.Load<Material>("Tile");
        foreach (GameObject obj in tiles)
        {
            obj.GetComponent<Renderer>().material = mat;
        }
    }
}
