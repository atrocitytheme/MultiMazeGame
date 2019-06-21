using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTaker : MonoBehaviour
{
    // Start is called before the first frame update
    private HashSet<int> tokens = new HashSet<int>();
    public bool Contains(int target) {
        return tokens.Contains(target);
    }
    public void Grab(int key) {
        tokens.Add(key);
    }
}
