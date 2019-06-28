using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Rule;
using Zinnia.Tracking.Modification;

public class TeleportPreventionSystem : MonoBehaviour, EventInterface
{
    public GameObject target; // The target with reciever
    public GameObject VRTK_setup; // the possible setup to follow
    public GameObject headsetAlias;
    public GameObject internalPointerLogic; // logic of internal pointer
    Vector3 temp = Vector3.zero;
    bool teleported = false;

    private void Start()
    {
        temp = target.transform.position;
        BindEvent(target);
    }
    //give teleporting timeout
    public void BindEvent(GameObject src)
    {
        Debug.Log("event bind! to: " + src.name);
        target.GetComponent<EventReceiver<Collider>>().Listen(Dedication);
    }
    // the registered event
    private void Dedication(Collider other)
    {
        if (other.tag == "mazeWall")
        {
            Debug.Log("staying!");
            target.transform.position += - temp * 2 * Time.deltaTime;
            Debug.Log(headsetAlias.transform.forward);
            VRTK_setup.transform.position = target.transform.position;
        }
    }

    public void SyncWithTeleport(TransformPropertyApplier.EventData data) {
        if (!teleported)
        {
            internalPointerLogic.SetActive(false);
            teleported = true;
            StartCoroutine(TeleportTimeout());
        }
        temp = data.EventTarget.Rotation * Vector3.forward;
    }

    private IEnumerator TeleportTimeout() {
        yield return new WaitForSeconds(0.3f);
        internalPointerLogic.SetActive(true);
        teleported = false;
    }
}
