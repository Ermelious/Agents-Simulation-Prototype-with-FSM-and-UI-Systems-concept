using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AbstractFiniteState
{
    public Enum stateID;
    public int stateLayer = 0;

    public StateStatus status = StateStatus.Exit;
    public StateStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public enum StateStatus { Triggered, Running, Exit, None };
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
    public abstract AbstractFiniteState SwitchStateDecision();
    public Enum GetStateID()
    {
        return stateID;
    }
}
