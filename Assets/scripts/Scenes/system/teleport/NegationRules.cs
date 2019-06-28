using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Extension;
using Zinnia.Rule;

public class NegationRules : MonoBehaviour, IRule
{
    public RuleContainer container;
    public bool Accepts(object obj) {
        Debug.Log("accepted!");
        return container.Accepts(obj);
    }
}
