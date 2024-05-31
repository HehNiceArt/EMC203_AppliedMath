using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsGO : MonoBehaviour
{
    public GameObject moveTowards;
    public GameObject p0, p1;
    public float moveSpeed = 2.0f;

    public void Start()
    {
        moveTowards.transform.position = p0.transform.position;
    }
    public void Update()
    {
        moveTowards.transform.position = new Vector3(
            Mathf.MoveTowards(moveTowards.transform.position.x, p1.transform.position.x, moveSpeed * Time.deltaTime),
            Mathf.MoveTowards(moveTowards.transform.position.y, p1.transform.position.y, moveSpeed * Time.deltaTime),
            Mathf.MoveTowards(moveTowards.transform.position.z, p1.transform.position.z, moveSpeed * Time.deltaTime)
        );

        if (Mathf.Approximately(moveTowards.transform.position.x, p1.transform.position.x))
        {
            moveTowards.transform.position = p0.transform.position;
        }
    }
}
