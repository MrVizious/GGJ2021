using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum LevelUpMethod
    {
        Time,
        Score
    }
    public LevelController levelController;
    public SpawnerLevels levels;
    public LevelUpMethod levelUpMethod;
    public Timer timer;
    // public Score score;

    private int currentLevel;
    private float lastSpawnTimeStamp = 0f;

    private void Start()
    {
        lastSpawnTimeStamp = 0f;
        currentLevel = 0;
    }

    private void Update()
    {
        switch (levelUpMethod)
        {
            case LevelUpMethod.Time:
                if (timer.secondsSinceStart
                    > levels.levels[currentLevel].maxPoint)
                {
                    currentLevel++;
                }
                if (timer.secondsSinceStart
                    >= lastSpawnTimeStamp + levels.levels[currentLevel].secondsBetweenSpawn)
                {
                    for (int i = 0; i < levels.levels[currentLevel].numberOfCombinationsToSpawn; i++)
                    {
                        levelController.AddCombination();
                    }
                }
                break;

                // TODO: Level up using score
                //case LevelUpMethod.Score:
                //    if
        }
    }


}