using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Sprite upSprite, downSprite;
    private Image buttonImage;
    private bool isPressed = false;

    private void Start()
    {
        isPressed = false;
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = upSprite;
        GetComponent<Animator>()?.Play(0, -1, Random.value);
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
