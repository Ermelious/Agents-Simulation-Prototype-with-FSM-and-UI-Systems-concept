using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCivilianFiniteState : AbstractFiniteState
{
    protected Civilian civilian;
    protected Dictionary<Enum, AbstractFiniteState> StateDictionary => civilian.stateDictionary;

    public AbstractCivilianFiniteState(Civilian civilian, Civilian.FSMStateID stateID, int stateLayer)
    {
        this.civilian = civilian;
        this.stateID = stateID;
        this.stateLayer = stateLayer;
    }
}
