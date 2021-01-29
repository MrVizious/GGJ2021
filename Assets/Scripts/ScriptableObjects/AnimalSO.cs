using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Animal", order = 1)]
public class AnimalSO : ScriptableObject
{
    public List<TraitSO> traits;
    public Sprite sprite;
}

