using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zinnia.Data.Type;

public class Player : MonoBehaviour
{
    public void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public virtual void FollowCamera(TransformData data)
    {
        transform.position = data.Position;
    }
}
