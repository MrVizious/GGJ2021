using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public Animation chosenAnimation;
    public ItemSO item;
    public TraitSO trait;
    public Left (Animation anim, ItemSO it, TraitSO tr)
    {
        chosenAnimation = anim;
        item = it;
        trait = tr;
    }
}
