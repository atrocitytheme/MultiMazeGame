using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public int keyType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") {
            other.GetComponent<KeyTaker>().Grab(keyType);
            Destroy(this.gameObject);
            Debug.Log("key grabbed!");
        }
    }
}
