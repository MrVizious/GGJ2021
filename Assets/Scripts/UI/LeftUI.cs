using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftUI : MonoBehaviour
{
    public LevelDataSO data;
    public Image itemImage;
    public Image traitImage;
    public Animator animator;

    private AnimatorOverrideController animatorOverrideController;

    private void Start()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }
    public void UpdateGraphics()
    {
        // Update images according to data
        Left currentLeft = data.getCurrentLeft();
        itemImage.sprite = currentLeft.item.sprite;
        traitImage.sprite = currentLeft.trait.sprite;
        SetClip(currentLeft.chosenAnimation);
    }

    private void SetClip(AnimationClip newClip)
    {
        if (!animatorOverrideController["LeftIdle"].Equals(newClip))
        {
            animatorOverrideController["LeftIdle"] = newClip;
        }
    }


}
