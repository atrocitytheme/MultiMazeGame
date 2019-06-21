using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
public class BackCommander : Commander
{
    // Start is called before the first frame update
    private Vector3 moveDir;
    public BackCommander(Animator anime,
        CharacterController controller,
        Transform transformer)
        : base(anime, controller, transformer)
    {
        moveDir = transformer.TransformDirection(new Vector3(0, 0, -1)* speed);
    }
    public override void Run() {
        anime.SetInteger("condition", 1);
        controller.Move(moveDir * Time.deltaTime);
    }
}
