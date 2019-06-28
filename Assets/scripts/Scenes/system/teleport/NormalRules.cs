using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Extension;
using Zinnia.Rule;

public class NormalRules : MonoBehaviour, IRule
{
    public RuleContainer container;
    public bool Accepts(object obj)
    {
        GameObject sd = (GameObject)obj;

        Debug.Log(sd.tag);
        return false;
    }
}
