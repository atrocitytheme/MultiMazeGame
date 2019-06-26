using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody body;
    bool destroyed = false;
    static float speed = 30.0f;

    public Ammo initialize() {
        body = GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;
        return this;
    }

    public Ammo DestroySelf() {
        if (!destroyed)
        {
            Destroy(this.gameObject);
            destroyed = true;
        }
        
        return this;
    }
}
