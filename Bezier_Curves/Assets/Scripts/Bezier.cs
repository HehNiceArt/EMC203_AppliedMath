using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode, RequireComponent (typeof(LineRenderer))]
public class Bezier : MonoBehaviour
{
    public Transform p0, p1, p2, p3;
    [Range(0,10)]
    public float Width;
    [Range(0,1)]
    public float _discSize = 0.15f;
    [Range(0,1)]
    public float lineWidth;
    public Color circle, midCircle, midFill, midConnector, bezier;
    [Range(0, 1)]
    public float t = 0;
    public int points = 20;
    public LineRenderer line;

    public Material mat;
    Vector3 _2DSpace = new Vector3(0, 0, 1);

    public static Bezier Instance { get; private set; }
    private void OnDrawGizmos()
    {
        Handles.color = circle;
        Handles.DrawSolidDisc(p0.position, _2DSpace, _discSize);
        Handles.Label(p0.position + Vector3.up /2, "p0");
        Handles.DrawSolidDisc(p1.position, _2DSpace, _discSize);
        Handles.Label(p1.position + Vector3.up /2, "p1");
        Handles.DrawSolidDisc(p2.position, _2DSpace, _discSize);
        Handles.Label(p2.position + Vector3.up /2, "p2");
        Handles.DrawSolidDisc(p3.position, _2DSpace, _discSize);
        Handles.Label(p3.position + Vector3.up /2, "p3");

        Handles.color = Color.white;
        Handles.DrawDottedLine(p0.position, p1.position, 5f);
        Handles.DrawDottedLine(p1.position, p2.position, 5f);
        Handles.DrawDottedLine(p2.position, p3.position, 5f);

        Vector3 p0top1 = Linear(p0.position, p1.position);
        Vector3 p1top2 = Linear(p1.position, p2.position);
        Vector3 p2top3 = Linear(p2.position, p3.position);

        Handles.color = midFill;
        Handles.DrawLine(p0.position, p0top1, Width);
        Handles.DrawLine(p1.position, p1top2, Width);
        Handles.DrawLine(p2.position, p2top3, Width);

        Handles.color = midCircle;
        Handles.DrawSolidDisc(p0top1, _2DSpace, _discSize);
        Handles.DrawSolidDisc(p1top2, _2DSpace, _discSize);
        Handles.DrawSolidDisc(p2top3, _2DSpace, _discSize);

        Handles.color = midConnector;
        Handles.DrawLine(p0top1, p1top2, Width);
        Handles.DrawLine(p1top2, p2top3, Width);

        Vector3 p0top2Mid = Linear(p0top1, p1top2);
        Vector3 p2top3Mid = Linear(p1top2, p2top3);
        Handles.Label(p0top2Mid + Vector3.up / 2, "p0 to p2");
        Handles.DrawSolidDisc(p0top2Mid, _2DSpace, _discSize);
        Handles.Label(p2top3Mid + Vector3.up / 2, "p1 to p3");
        Handles.DrawSolidDisc(p2top3Mid, _2DSpace, _discSize);

        Handles.color = bezier;
        Handles.DrawLine(p0top2Mid, p2top3Mid, Width);
        Vector3 cubicMid = Linear(p0top2Mid, p2top3Mid);
        Handles.DrawSolidDisc(cubicMid, _2DSpace, _discSize);
    }
   
    public virtual void Update()
    {
        if (points > 0)
        {
            line.positionCount = points;
        }

        mat.SetColor("_Color", bezier);
            Vector3 pos;
        for (int i = 0; i < points; i++)
        {
            float _t = i / (points - 1.0f);
            float _t2 = _t * _t;
            float _t3 = _t * _t * _t;
            float oneT = 1.0f - _t;
            float oneT2 = oneT * oneT;
            float oneT3 = oneT * oneT * oneT;

            Vector3 _p0 = p0.position;
            Vector3 _p1 = p1.position;
            Vector3 _p2 = p2.position;
            Vector3 _p3 = p3.position;
            //Quadratic
            //pos = oneT2 * _p0 + 2.0f * oneT * _t * _p1 + _t2 * _p2;

            //Cubic
            pos = oneT3 * _p0 + 3 * oneT2 * _t * _p1 + (3 * oneT * _t2) * _p2 + _t3 * _p3;

            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            line.SetPosition(i, pos);
        }
    }

    public Vector3 Linear(Vector3 p0, Vector3 p1)
    {
        Vector3 linear = (1 - t) * p0 + t * p1;
        return linear;
    }
}
