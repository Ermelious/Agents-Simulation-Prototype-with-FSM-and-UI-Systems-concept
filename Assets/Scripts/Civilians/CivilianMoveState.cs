using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianMoveState : AbstractCivilianFiniteState
{
    public CivilianMoveState(Civilian civilian, Civilian.FSMStateID stateID, int stateLayer) : base(civilian, stateID, stateLayer)
    {
    }

    public override void OnEnter()
    {
        // Go to next way point.
        if (civilian.currentRoute.WayPoints.Last != civilian.currentWayPoint)
            civilian.currentWayPoint = civilian.currentWayPoint.Next;
        else
            civilian.currentWayPoint = civilian.currentRoute.WayPoints.First;
        civilian.Agent.SetDestination(civilian.currentWayPoint.Value.Position);
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnUpdate()
    {
        civilian.Animator.SetFloat("horizontalVelocity", civilian.Agent.velocity.Horizontal(0).magnitude);
    }

    public override AbstractFiniteState SwitchStateDecision()
    {
        if (civilian.Agent.remainingDistance <= civilian.Agent.stoppingDistance)
            return StateDictionary[Civilian.FSMStateID.Idle];
        return this;
    }
}
