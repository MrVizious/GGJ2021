using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Animal", order = 1)]
public class AnimalSO : ScriptableObject
{
    public string animalName = "Animal";
    public List<TraitSO> traits;
    public List<Animation> animations;

    public Animation getRandomAnimation()
    {
        return animations[Random.Range(0, animations.Count - 1)];
    }

    public TraitSO getRandomTrait()
    {
        return traits[Random.Range(0, traits.Count - 1)];
    }
}