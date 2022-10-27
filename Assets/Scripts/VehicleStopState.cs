using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStopState : AbstractVehicleFiniteState
{
    public VehicleStopState(Vehicle vehicle, Vehicle.FSMStateID stateID, int stateLayer) : base(vehicle, stateID, stateLayer)
    {
    }

    public override void OnEnter()
    {
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
        if (!vehicle.Agent.isOnNavMesh)
            return this;
        if (vehicle.currentRoute != null)
            return StateDictionary[Vehicle.FSMStateID.Move];
        return this;
    }
}
