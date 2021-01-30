using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Left
{
    public AnimationClip chosenAnimation;
    public ItemSO item;
    public TraitSO trait;
    public Left(AnimationClip anim, ItemSO it, TraitSO tr)
    {
        chosenAnimation = anim;
        item = it;
        trait = tr;
    }
}
