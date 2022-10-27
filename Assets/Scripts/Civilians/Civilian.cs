using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : Bot
{
    public enum FSMStateID { Idle, Move }

    public Route currentRoute;
    public LinkedListNode<Waypoint> currentWayPoint;

    private void Awake()
    {
        stateDictionary.Add(FSMStateID.Idle, new CivilianIdleState(this, FSMStateID.Idle, 0));
        stateDictionary.Add(FSMStateID.Move, new CivilianMoveState(this, FSMStateID.Move, 0));

        AddNewStateLayer(stateDictionary[FSMStateID.Idle]);
    }

    public void Init(Route route)
    {
        SwitchState(0, FSMStateID.Idle);
        currentRoute = route;
        currentWayPoint = currentRoute.WayPoints.First;
        int randomWayPointIndex = Random.Range(0, currentRoute.WayPoints.Count);

        for (int index = 0; index < randomWayPointIndex; index++)
            currentWayPoint = currentWayPoint.Next;

        Agent.Warp(currentWayPoint.Value.Position);
    }
}
