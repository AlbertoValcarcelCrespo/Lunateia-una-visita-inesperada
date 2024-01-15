using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachines : MonoBehaviour
{
    private State currentState;

    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Execute();
    }
}

public class Enemy : MonoBehaviour
{
    private StateMachines stateMachine = new StateMachines();

    void Start()
    {
        stateMachine.ChangeState(new PatrolState());
    }

    void Update()
    {
        stateMachine.Update();
    }
}