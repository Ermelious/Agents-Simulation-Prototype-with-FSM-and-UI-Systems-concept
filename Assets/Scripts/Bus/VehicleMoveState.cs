using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMoveState : AbstractVehicleFiniteState
{
    public VehicleMoveState(Vehicle vehicle, Vehicle.FSMStateID stateID, int stateLayer) : base(vehicle, stateID, stateLayer)
    {
    }

    public override void OnEnter()
    {
        // Go to next way point.
        if (vehicle.currentRoute.WayPoints.Last != vehicle.currentWayPoint)
            vehicle.currentWayPoint = vehicle.currentWayPoint.Next;
        else
            vehicle.currentWayPoint = vehicle.currentRoute.WayPoints.First;
        vehicle.Agent.SetDestination(vehicle.currentWayPoint.Value.Position);
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnUpdate()
    {
    }

    public override AbstractFiniteState SwitchStateDecision()
    {
        if (vehicle.Agent.remainingDistance <= vehicle.Agent.stoppingDistance)
            return StateDictionary[Vehicle.FSMStateID.Stop];
        return this;
    }
}
