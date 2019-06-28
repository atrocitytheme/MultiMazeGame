using UnityEngine;
using Zinnia.Data.Type;

public class CameraFollower : MonoBehaviour
{
    public virtual void FollowCamera(TransformData data)
    {
        if (transform.position != data.Position)
        transform.position = data.Position;
    }
}
