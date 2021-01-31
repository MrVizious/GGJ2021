using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 1)]
public class ScoreSO : ScriptableObject
{
    public int currentScore = 0;
    public int increaseAmount = 50;
    public int decreaseAmount = 25;

    public void IncreaseScore()
    {
        IncreaseScore(increaseAmount);
    }

    public void IncreaseScore(int amount)
    {
        currentScore += amount;
    }
    public void DecreaseScore()
    {
        DecreaseScore(decreaseAmount);
    }

    public void DecreaseScore(int amount)
    {
        currentScore = Mathf.Clamp(
            currentScore - amount,
            0,
            int.MaxValue
        );
    }

    public void Reset()
    {
        currentScore = 0;
    }
}
