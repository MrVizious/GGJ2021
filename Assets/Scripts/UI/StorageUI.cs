using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageUI : MonoBehaviour
{
    public LevelDataSO data;
    public Image[] storageImages;

    private void Start()
    {
        if (storageImages == null || storageImages.Length == 0)
        {
            storageImages = new Image[2];
        }

        UpdateGraphics();
    }

    public void UpdateGraphics()
    {
        for (int i = 0; i < storageImages.Length; i++)
        {
            storageImages[i].sprite = data.storaged[i].item.sprite;
        }
    }
}
