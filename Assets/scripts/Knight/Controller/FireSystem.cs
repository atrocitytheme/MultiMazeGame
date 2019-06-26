using System.Collections;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerBody;
    private bool ammoGenerated = false;

    public void Fire()
    {
        Debug.Log("Fire!");
        if (!ammoGenerated)
        {
            GameObject ammo = CreateAmmo();
            var amo = ammo.GetComponent<Ammo>().initialize();
            ammoGenerated = true;
            StartCoroutine(ProcessAmmo(amo));
        }
    }

    GameObject CreateAmmo()
    {
        GameObject ammo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ammo.tag = "ammo";
        ammo.name = "ammo";
        Quaternion newRotate = playerBody.transform.rotation;

        ammo.transform.rotation = newRotate;

        ammo.transform.position = playerBody.transform.position;
        var collider = ammo.GetComponent<SphereCollider>();
        collider.isTrigger = true;
        var body = ammo.AddComponent<Rigidbody>();
        body.useGravity = false;
        ammo.AddComponent<Ammo>();
        return ammo;
    }

    IEnumerator ProcessAmmo(Ammo ammo)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Ammo Released!");
        ammo.DestroySelf();
        ammoGenerated = false;
    }
}
