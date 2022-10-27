using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Bot : AbstractFiniteStateMachine
{
    [SerializeField]
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField]
    private Animator animator;
    public Animator Animator => animator;
    [SerializeField]
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private void OnValidate()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
}
