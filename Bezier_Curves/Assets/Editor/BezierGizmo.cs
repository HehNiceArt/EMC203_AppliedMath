using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bezier)), CanEditMultipleObjects]
public class BezierGizmo : Editor
{
    public void OnSceneGUI()
    {
        Bezier bezier = (Bezier)target;
        EditorGUI.BeginChangeCheck();
        Vector3 newp0Target = Handles.PositionHandle(bezier.p0.position, Quaternion.identity);
        Vector3 newp1Target = Handles.PositionHandle(bezier.p1.position, Quaternion.identity);
        Vector3 newp2Target = Handles.PositionHandle(bezier.p2.position, Quaternion.identity);
        Vector3 newp3Target = Handles.PositionHandle(bezier.p3.position, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(bezier, "Change Look At Target Postion");
            bezier.p0.position = newp0Target;
            bezier.p1.position = newp1Target;
            bezier.p2.position = newp2Target;
            bezier.p3.position = newp3Target;
            bezier.Update();
        }

    }
}
