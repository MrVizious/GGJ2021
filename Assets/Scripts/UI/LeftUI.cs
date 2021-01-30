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
        // TODO: Check that the new is different from the current
        // Debug.Log("Newclip: " + newClip);

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
