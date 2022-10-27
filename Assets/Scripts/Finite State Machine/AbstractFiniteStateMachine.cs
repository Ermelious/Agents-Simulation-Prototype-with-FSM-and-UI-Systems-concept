using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static AbstractFiniteState;

public abstract class AbstractFiniteStateMachine : MonoBehaviour
{
    public List<AbstractFiniteState> currentStates = new List<AbstractFiniteState>();
    public List<string> currentStatesDisplay;
    public Dictionary<Enum, AbstractFiniteState> stateDictionary = new Dictionary<Enum, AbstractFiniteState>();
    public List<AbstractFiniteState> defaultStates = new List<AbstractFiniteState>();

    private void OnEnable()
    {
        ReturnToDefaultState();
    }

    /// <summary>
    /// Resets all Finite State Layers to Default States.
    /// </summary>
    protected void ReturnToDefaultState()
    {
        for (int layerIndex = 0; layerIndex < currentStates.Count; layerIndex++)
        {
            SwitchState(layerIndex, defaultStates[layerIndex].GetStateID());
        }
    }

    /// <summary>
    /// Switch to another state, this should only be used for switching of states from other State Layers.
    /// </summary>
    /// <param name="stateLayerIndex"></param>
    /// <param name="finiteState"></param>
    public void SwitchState(int stateLayerIndex, Enum stateId)
    {
        //Attempts to switch to the same state from the current state will be rejected.
        if (currentStates[stateLayerIndex].stateID == stateId)
            return;
        currentStates[stateLayerIndex].OnExit();
        currentStates[stateLayerIndex].status = StateStatus.Exit;
        currentStates[stateLayerIndex] = stateDictionary[stateId];
        currentStatesDisplay[stateLayerIndex] = stateDictionary[stateId].GetStateID().ToString();
        currentStates[stateLayerIndex].status = StateStatus.Running;
        currentStates[stateLayerIndex].OnEnter();
    }

    public virtual void Update()
    {
        for (int stateLayerIndex = 0; stateLayerIndex < currentStates.Count; stateLayerIndex++)
        {
            currentStates[stateLayerIndex].OnUpdate();

            potentialNextState = currentStates[stateLayerIndex].SwitchStateDecision();
            // Switch State Check
            if (!CheckIfSameState(currentStates[stateLayerIndex], potentialNextState))
                SwitchState(stateLayerIndex, potentialNextState.GetStateID());
            //else
                //currentStates[stateLayerIndex].status = StateStatus.Running; //This ensures that we don't take in multiple triggers for the same state.
        }
    }

    private AbstractFiniteState potentialNextState;
    public virtual void FixedUpdate()
    {
        for (int stateLayerIndex = 0; stateLayerIndex < currentStates.Count; stateLayerIndex++)
        {
            currentStates[stateLayerIndex].OnFixedUpdate();
        }
    }

    private bool CheckIfSameState(AbstractFiniteState currentState, AbstractFiniteState potentialNextState)
    {
        return currentState.GetStateID() == potentialNextState.GetStateID();
    }

    protected void AddNewStateLayer(AbstractFiniteState initialState)
    {
        currentStates.Add(initialState);
        currentStatesDisplay.Add(initialState.GetStateID().ToString());
        defaultStates.Add(initialState);
        initialState.Status = StateStatus.Running;
    }

    public T GetCurrentState<T>(int layerID) where T : Enum
    {
        return (T)currentStates[layerID].GetStateID();
    }

    private void OnDisable()
    {
        //currentStates.Clear();
        //currentStatesDisplay.Clear();
    }
}
