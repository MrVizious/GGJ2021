using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerLevels", menuName = "ScriptableObjects/SpawnerLevels", order = 1)]
public class SpawnerLevels : ScriptableObject
{
    [System.Serializable]
    public struct SpawnerLevel
    {
        public int maxPoint;
        public float secondsBetweenSpawn;
        public int numberOfCombinationsToSpawn;
    }

    public List<SpawnerLevel> levels;


}
