using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifterTrigger : MonoBehaviour
{
    [SerializeField]
    public Lifter lifter;

    public int keyType;

    bool triggered = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Collider player = collision.collider;
        if (!lifter.Triggered && collision.collider.tag == "player") {
            if (!CheckPlayerValid(player)) {
                return;
            };
            lifter.Trigger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider player = other;
        if (!lifter.Triggered && other.tag == "player") {
            if (!CheckPlayerValid(player)) {
                return;
            };
            lifter.Trigger();
        }
    }

    private bool CheckPlayerValid(Collider player) {
        KeyTaker onHand = player.GetComponent<KeyTaker>();
        return onHand.Contains(keyType);
    }


}
