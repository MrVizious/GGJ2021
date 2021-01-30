using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelDataSO data;
    public int initialCombinations = 10;
    public int maxNumberOfTries = 10;
    private ResourceLoader loader;

    private void Awake()
    {
        data.Setup();
    }
    void Start()
    {
        loader = ResourceLoader.Instance;
        for (int count = 0; count < initialCombinations; count++)
        {
            AddCombination();
        }
    }

    public void AddCombination()
    {
        bool added = false;
        for (int count = 0; count < maxNumberOfTries && !added; count++)
        {
            ItemSO item = loader.getRandomItem();
            AnimalSO animalRight = loader.getRandomAnimal();
            AnimalSO animalLeft = loader.getRandomAnimal();
            added = data.AddCombination(animalLeft, animalRight, item);
            if (!added && count == maxNumberOfTries - 1) data.AddCombinationWithoutChecking(animalLeft, animalRight, item);
        }
    }
}
