using UnityEngine;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().Die();
    }
}
