using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightUI : MonoBehaviour
{
    public LevelDataSO data;
    public Image itemImage;
    public Animator animalAnimator;

    private void Start()
    {
        UpdateGraphics();
    }
    public void UpdateGraphics()
    {
        // Update images according to data
        Right currentRight = data.getCurrentRight();
        itemImage.sprite = currentRight.item.spriteOutline;
        SetClip(currentRight.chosenAnimation);
    }
    private void SetClip(AnimationClip newClip)
    {
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
