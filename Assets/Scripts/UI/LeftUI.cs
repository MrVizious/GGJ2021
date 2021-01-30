using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftUI : MonoBehaviour
{
    public LevelDataSO data;
    public Image itemImage;
    public Image traitImage;
    public Animator animalAnimator;

    private AnimatorOverrideController animatorOverrideController;

    private void Start()
    {
        UpdateGraphics();
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
        animatorOverrideController = new AnimatorOverrideController(animalAnimator.runtimeAnimatorController);
        AnimationClip currentClip = animatorOverrideController["LeftIdle"];
        Debug.Log(currentClip == null);
        Debug.Log("Newclip: " + newClip);

        // if (currentClip == null || !currentClip.Equals(newClip))
        // {
        //     Debug.Log("Changing");
        // }
        // animatorOverrideController["LeftIdle"] = newClip;
        // animalAnimator.runtimeAnimatorController = animatorOverrideController;

        if (newClip)
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(animalAnimator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            foreach (var a in aoc.animationClips)
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, newClip));
            aoc.ApplyOverrides(anims);
            animalAnimator.runtimeAnimatorController = aoc;
        }
    }


}
