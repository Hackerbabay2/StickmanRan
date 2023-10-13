using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class AiUnit : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        AiManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 position)
    {
        _agent.SetDestination(position);
    }
}
