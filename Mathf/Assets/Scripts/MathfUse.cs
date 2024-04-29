using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
using UnityEngine;

[ExecuteInEditMode]
public class MathfUse : MonoBehaviour
{
    //public Slider lerpSlider, moveTowards, pingPong;
    public float magnitude;
    public float speed;
    public Vector3 startPos;
    public bool PingPong, Sin, Slerp, MoveTowards, Lerp;
    [Space(10)]
    public Transform start, end, center;
    public int count;
    public float rad = 1;

    private void Update()
    {
        //Mathf.Abs(); 
        //Mathf.RoundToInt();
        //Mathf.CeilToInt();
        //Mathf.FloorToInt();
        //Mathf.Pow();
        //Mathf.Sqrt();
        //Mathf.Clamp();
        Debug.Log("grr");
        //lerpSlider.value = Mathf.Lerp(lerpSlider.value, lerpSlider.maxValue, speed * Time.deltaTime);
        //moveTowards.value = Mathf.MoveTowards(moveTowards.value, moveTowards.maxValue, speed * Time.deltaTime);
        //pingPong.value = Mathf.PingPong();

        if(PingPong) transform.position = new Vector3(0, PingPongAmount(), 0);
        if(Sin) transform.position = new Vector3(0, SinAmount(), 0);

    }

    private void OnDrawGizmos()
    {
        foreach(var point in EvaluateSlerp(start.position, center.position, end.position, count))
        {
            Gizmos.DrawSphere(point, rad / 2);
        }
            Gizmos.color = Color.red;
        Gizmos.DrawSphere (center.position, rad / 2);
        
    }
    IEnumerable<Vector3> EvaluateSlerp(Vector3 start, Vector3 center, Vector3 end, int count)
    {
        var getStart = start - center;
        var getEnd = end - center;
        var f = 1f / count;
        for (float i = 0; i < 1 + f; i += f)
        {
           yield return Vector3.Slerp(getStart, getEnd, i) + center; 
        }
    }
    float PingPongAmount()
    {
        return Mathf.PingPong(Time.time * speed, magnitude);
    }
    float SinAmount()
    {
        return Mathf.Sin(Time.time * speed);
    }
}
