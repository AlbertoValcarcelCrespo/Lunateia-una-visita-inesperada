using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavHuesitos : MonoBehaviour
{
    public Transform obj;
    private NavMeshAgent ag;

    private void Awake()
    {
        ag = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ag = GetComponent<NavMeshAgent>();

        ag.updateRotation = false;
        ag.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        ag.SetDestination(obj.position);
    }
}
