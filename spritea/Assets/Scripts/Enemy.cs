using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float viewDist;
    public float viewAngle;

    Vector3 lastSeen;
    Vector3 target;

    void Start()
    {
        lastSeen = transform.position; 
        target = player.transform.position;
    }

    bool SeePlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        if(dir.magnitude < viewDist)
        {
            Debug.DrawRay(transform.position, transform.up * viewDist, Color.yellow);
            Debug.DrawRay(transform.position, dir.normalized * viewDist, Color.yellow);
            float angle = Vector3.Dot(transform.up, dir.normalized);
            if((Mathf.Acos(angle) * Mathf.Rad2Deg) < viewAngle)
            {
            return true;

            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        bool seen= SeePlayer();
        if(seen)
        {
            lastSeen = player.transform.position;
            target = lastSeen;
        }
        if(Vector3.Distance(transform.position, target) < 0.5f)
        {
            Quaternion rot = Quaternion.Euler(0,0, Random.Range(0, 360));
            target = lastSeen + (rot * transform.up * 5f);
        }
        else
        {
            Vector3 dir = target - transform.position;
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            Quaternion p = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * 10f);

            transform.position += transform.up * 50f * Time.deltaTime;
        }
        Debug.DrawRay(transform.position, transform.up * viewDist, seen? Color.red: Color.yellow);
        Quaternion rayAngle = Quaternion.Euler(0, 0, -viewAngle);
        Debug.DrawRay(transform.position, rayAngle * transform.up * viewAngle, seen? Color.red: Color.yellow);
        Quaternion rayAngleP = Quaternion.Euler(0,0, viewAngle);
        Debug.DrawRay(transform.position, rayAngleP * transform.up * viewAngle, seen? Color.red: Color.yellow);
    }
}
