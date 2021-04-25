using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    public Vector3 Position => transform.position;

    public Waypoint GetNovoWaypoint()
    {
        if(waypoints.Count == 0)
        {
            return null;
        }
        if(waypoints.Count == 1)
        {
            return waypoints[0];
        }

        int random = Random.Range(0, waypoints.Count);
        return waypoints[random];
    }
}
