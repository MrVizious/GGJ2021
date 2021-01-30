using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Image buttonImage;
    public Sprite upSprite, downSprite;
    private bool isPressed = false;

    private void Start()
    {
        isPressed = false;
        buttonImage.sprite = upSprite;
    }

    public void Press()
    {
        setPressed(true);
    }
    public void Release()
    {
        setPressed(false);
    }

    public void Toggle()
    {
        setPressed(!isPressed);
    }

    public void setPressed(bool newValue)
    {
        isPressed = newValue;
        UpdateGraphics();
    }

    private void UpdateGraphics()
    {
        buttonImage.sprite = isPressed ? downSprite : upSprite;
    }
}
