using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, Hittable, Freezable
{
    // Start is called before the first frame update
    private static float FREEZE_TIME = 8f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ammo") {
            Debug.Log("deactivated!");
            other.GetComponent<Ammo>().DestroySelf();
            Freeze();
        }

        if (other.tag == "player") {
            other.GetComponent<Player>().Die();
            Destroy(this.gameObject);
        }
    }

    public void Damage(Player player) {

    }

    public void Freeze() {
        Enemy self = GetComponent<Enemy>();
        StartCoroutine(Pause(self));
    }

    IEnumerator Pause(Enemy self) {
        self.Deactivate();
        yield return new WaitForSeconds(FREEZE_TIME);
        self.Activate();
    }
}
