using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject p1, p2;
    public bool isPoint = false;
    void Update()
    {
        if(isPoint)
        {
            Vector3 movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += Vector3.back;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
            p1.transform.position += movement * moveSpeed * Time.deltaTime;
        }    
        else if (!isPoint)
        {
            Vector3 movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += Vector3.back;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
            p2.transform.position += movement * moveSpeed * Time.deltaTime; 
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isPoint = !isPoint;
        }
    }
}
