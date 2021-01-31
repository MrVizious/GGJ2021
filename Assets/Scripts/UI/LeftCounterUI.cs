using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCounterUI : MonoBehaviour
{
    public LevelDataSO data;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = (data.leftIndex + 1) + "/" + data.leftList.Count;
    }
}
