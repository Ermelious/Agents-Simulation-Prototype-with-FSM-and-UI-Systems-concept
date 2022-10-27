using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianIdleState : AbstractCivilianFiniteState
{
    public CivilianIdleState(Civilian civilian, Civilian.FSMStateID stateID, int stateLayer) : base(civilian, stateID, stateLayer)
    {
    }

    public override void OnEnter()
    {
        civilian.Animator.SetFloat("horizontalVelocity", 0);
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
        if (!civilian.Agent.isOnNavMesh)
            return this;
        if (civilian.currentRoute != null)
            return StateDictionary[Civilian.FSMStateID.Move];
        return this;
    }
}
