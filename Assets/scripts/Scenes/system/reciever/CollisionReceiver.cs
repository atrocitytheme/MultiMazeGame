using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReceiver : MonoBehaviour, EventReceiver<Collider>
{
    // Start is called before the first frame update

    private Action<Collider> currentEvent;
    private bool registered = false;
    private bool triggered = false;
    Collider collide;
    private void Update()
    {
        if (triggered) {
            currentEvent(collide);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (registered && !triggered) {
            StartCoroutine(Task(collider));
        }
    }
  
    private void OnTriggerStay(Collider other)
    {
        if (registered) {
            currentEvent(other);
        }
    }

    public void Listen(Action<Collider> action) {
        Debug.Log("collision received!");
        registered = true;
        currentEvent = action;
    }

    IEnumerator Task(Collider coll) {
        triggered = true;
        collide = coll;
        yield return new WaitForSeconds(2f);
        triggered = false;
        collide = null;
    }
}
