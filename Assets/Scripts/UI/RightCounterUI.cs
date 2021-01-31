using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightCounterUI : MonoBehaviour
{
    public LevelDataSO data;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = (data.rightIndex + 1) + "/" + data.rightList.Count;
    }
}
