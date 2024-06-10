using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class CubeSpawnEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridGenerator gridGenerator = (GridGenerator)target;

        if (GUILayout.Button("Assign Material"))
        {
            gridGenerator.AssignMaterial();
        }
    }
    [MenuItem("Tools/Generate Grid")]
    public static void GenerateGridMenu()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();

        if(gridGenerator != null)
        {
            gridGenerator.GenerateGrid();
        }
    }
    [MenuItem("Tools/Clear Grid")]
    public static void ClearGridMenu()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();

        if (gridGenerator != null)
        {
            gridGenerator.ClearGrid();
        }
    }
}
