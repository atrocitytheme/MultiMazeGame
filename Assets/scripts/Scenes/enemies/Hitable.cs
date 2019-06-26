using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Hittable
{
    void Damage(Player player); // do damage to the player
}
