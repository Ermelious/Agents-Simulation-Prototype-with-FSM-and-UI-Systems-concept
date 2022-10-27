using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : Bot
{
    public enum FSMStateID { Stop, Move, AtStation };

    [Header("Customizables")]
    [SerializeField]
    private int maximumPassengerCapacity;
    [Header("Monitor")]
    [SerializeField]
    public List<Civilian> civilians = new List<Civilian>();
    public List<Civilian> Civilians => civilians;
    public Route currentRoute;
    public LinkedListNode<Waypoint> currentWayPoint;

    private void Awake()
    {
        stateDictionary.Add(FSMStateID.Stop, new VehicleStopState(this, FSMStateID.Stop, 0));
        stateDictionary.Add(FSMStateID.Move, new VehicleMoveState(this, FSMStateID.Move, 0));
        stateDictionary.Add(FSMStateID.AtStation, new VehicleAtStationState(this, FSMStateID.AtStation, 0));

        AddNewStateLayer(stateDictionary[FSMStateID.Stop]);
    }

    public void Init(Route route)
    {
        SwitchState(0, FSMStateID.Stop);
        currentRoute = route;
        currentWayPoint = currentRoute.WayPoints.First;
        int randomWayPointIndex = Random.Range(0, currentRoute.WayPoints.Count);

        for (int index = 0; index < randomWayPointIndex; index++)
            currentWayPoint = currentWayPoint.Next;

        Agent.Warp(currentWayPoint.Value.Position);
    }
}
