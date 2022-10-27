using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAtStationState : AbstractVehicleFiniteState
{
    public VehicleAtStationState(Vehicle vehicle, Vehicle.FSMStateID stateID, int stateLayer) : base(vehicle, stateID, stateLayer)
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
        return this;
    }
}
