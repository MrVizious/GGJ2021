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

    private AnimatorOverrideController animatorOverride;

    private void Start()
    {

    }
    public void UpdateGraphics()
    {
        // Update images according to data
        Left currentLeft = data.getCurrentLeft();
        itemImage.sprite = currentLeft.item.sprite;
        traitImage.sprite = currentLeft.trait.sprite;
    }

    private void SetClip(AnimationClip newClip)
    {

    }


}
