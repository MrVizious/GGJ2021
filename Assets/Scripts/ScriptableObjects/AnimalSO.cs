using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Animal", order = 1)]
public class AnimalSO : ScriptableObject
{
    public string animalName = "Animal";
    public List<TraitSO> traits;
    public List<AnimationClip> animations;

    public AnimationClip getRandomAnimation()
    {
        return animations[Random.Range(0, animations.Count)];
    }

    public TraitSO getRandomTrait()
    {
        return traits[Random.Range(0, traits.Count)];
    }
}