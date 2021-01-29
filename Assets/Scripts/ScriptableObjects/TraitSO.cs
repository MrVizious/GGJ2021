using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trait", menuName = "ScriptableObjects/Trait", order = 1)]
public class TraitSO : ScriptableObject
{
    public string traitName = "Trait";
    public Sprite sprite;
}
