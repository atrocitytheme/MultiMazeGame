using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject whoToTrack;
    public bool isActivated = false;
    NavMeshAgent agent;
    float speedTemp;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speedTemp = agent.speed;
    }
    public bool active {
        get {
            return isActivated;
        }
    }
    // Start is called before the first frame update
    public void Activate() {
        agent.speed = speedTemp + 0.2f;
        isActivated = true;
    }

    public void Deactivate() {
        speedTemp = agent.speed;
        agent.speed = 0;
        isActivated = false;
    }

    private void FixedUpdate()
    {
        if (isActivated) agent.SetDestination(whoToTrack.transform.position);
    }
}
