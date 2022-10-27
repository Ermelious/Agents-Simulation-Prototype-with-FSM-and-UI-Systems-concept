using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> waypoints = new List<Waypoint>();
    public LinkedList<Waypoint> WayPoints = new LinkedList<Waypoint>();

    private void OnValidate()
    {
        waypoints = GetComponentsInChildren<Waypoint>().ToList();
    }

    private void Awake()
    {
        foreach (Waypoint waypoint in waypoints)
            WayPoints.AddLast(waypoint);
    }
}
