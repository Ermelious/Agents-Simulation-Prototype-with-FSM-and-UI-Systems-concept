using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVehicleFiniteState : AbstractFiniteState
{
    protected Vehicle vehicle;
    protected Dictionary<Enum, AbstractFiniteState> StateDictionary => vehicle.stateDictionary;

    public AbstractVehicleFiniteState(Vehicle vehicle, Vehicle.FSMStateID stateID, int stateLayer)
    {
        this.vehicle = vehicle;
        this.stateID = stateID;
        this.stateLayer = stateLayer;
    }
}
