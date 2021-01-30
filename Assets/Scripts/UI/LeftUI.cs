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
        animatorOverrideController = new AnimatorOverrideController(animalAnimator.runtimeAnimatorController);
        animalAnimator.runtimeAnimatorController = animatorOverrideController;
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
        AnimationClip currentClip = animatorOverrideController["LeftIdle"];
        Debug.Log("Current clip is: " + currentClip);
        Debug.Log("New clip is: " + newClip);



        bool areEqual = (!animatorOverrideController["LeftIdle"].Equals(newClip));
        if (!areEqual)
        {
            animatorOverrideController["LeftIdle"] = newClip;
        }
        Debug.Log("Got here");
    }


}
