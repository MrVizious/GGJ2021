using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right
{
    public AnimationClip chosenAnimation;
    public ItemSO item;
    public AnimalSO animal;
    public Right(AnimationClip anim, ItemSO it, AnimalSO ani)
    {
        chosenAnimation = anim;
        item = it;
        animal = ani;
    }
}
