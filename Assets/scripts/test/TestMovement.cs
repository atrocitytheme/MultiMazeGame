using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destination;
    void Start() {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.transform.position);
    }
}
