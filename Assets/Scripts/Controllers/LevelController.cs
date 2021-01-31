using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Variable public storageAction(index)
    //index =0||1, if storage A or B
    //if rightList < 10: AddCombination until 10
    //Add eventListeners: onStorageADown, onStorageBDown
    public LevelDataSO data;
    public ScoreSO score;
    public int initialCombinations = 10;
    public int maxNumberOfTries = 10;
    private ResourceLoader loader;

    private void Awake()
    {
        data.Setup();
        score.Reset();
    }
    private void OnEnable()
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

    public void RotateLeft(int amount)
    {
        data.RotateLeft(amount);
    }
    public void RotateRight(int amount)
    {
        data.RotateRight(amount);
    }
    public void StorageAction(int index)
    {
        data.StorageAction(index);
        while (data.rightList.Count < initialCombinations)
        {
            AddCombination();
        }
    }

    public void IncreaseScore()
    {
        score.IncreaseScore();
    }

    public void DecreaseScore()
    {
        score.DecreaseScore();
    }
}
