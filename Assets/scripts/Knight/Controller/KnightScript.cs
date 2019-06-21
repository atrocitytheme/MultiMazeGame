using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
public class KnightScript : MonoBehaviour
{
    // Start is called before the first frame update
    float rotSpeed = 4;
    float gravity = 4;
    float rotation = 0;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;

    Animator anime;
    private Commander commander;

    bool isLookUp = false;
    bool shouldJump = true;

    public bool ShouldJump {
        get {
            return shouldJump;
        }

        set {
            shouldJump = value;
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anime = GetComponent<Animator>();
    }

    private void Update()
    {
        if (true) {
            if (Input.GetKey("w")) {
                commander = new ForwardCommander(anime, controller, transform);
                commander.Run();
            }

            if (Input.GetKeyUp("w")) {
                commander = new ForwardCommander(anime, controller, transform);
                commander.Cancel();
            }

            if (Input.GetKey(KeyCode.Space)) {
                if (shouldJump) StartCoroutine(Jump());
            }

            if (Input.GetKey("s")) {
                commander = new BackCommander(anime, controller, transform);
                commander.Run();
            }

            if (Input.GetKeyUp("s"))
            {
                commander = new BackCommander(anime, controller, transform);
                commander.Cancel();
            }

        }
        rotation += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        if (!isLookUp)
        transform.eulerAngles = new Vector3(0, 10*rotation, 0);
    }

    IEnumerator Attack() {
        anime.SetBool("attackTimeout", false);
        yield return new WaitForSeconds(1f);
        anime.SetInteger("condition", 2);
        yield return new WaitForSeconds(0.01f);
        int state = (anime.GetInteger("condition") != 0) ? 1 : 0;
        anime.SetInteger("condition", state);
        anime.SetBool("attackTimeout", true);
    }

    public IEnumerator Jump() {
        shouldJump = false;
        GetComponent<CharacterController>().Move(new Vector3(0, 200, 0) * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        shouldJump = true;
    }
}
