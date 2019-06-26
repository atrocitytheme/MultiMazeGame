using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Prefabs.Pointers;
using Zinnia.Data.Type;

public class TestRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectFollowing;
    public GameObject alias;
    public virtual void ListenData(TransformData data) {
        Debug.Log("the current transform data is: ");
        Debug.Log(data.Position);
    }
    public virtual void FollowCamera(TransformData data) {
        objectFollowing.transform.position = data.Position;
    }
}
