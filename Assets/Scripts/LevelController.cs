using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<Left> leftList;
    private List<Right> rightList;
    //private int leftIndex, rightIndex = 0;
    private ResourceLoader loader;

    void Start()
    {
        leftList = new List<Left>();
        rightList = new List<Right>();

        loader = ResourceLoader.Instance;
        for(int count=0; count<10;count++)
        {
            AddCombination();
        }    
    }

    public void AddCombination()
    {
        AnimalSO animalRight=loader.getRandomAnimal();
        AnimalSO animalLeft=loader.getRandomAnimal();

        for(int count=0; count<10; count++)
        {
            if(animalLeft.Equals(animalRight))
            {
                animalRight = loader.getRandomAnimal();
                animalLeft = loader.getRandomAnimal();
            }else
            {
                break;
            }
        }

        //Creation object left/giver
        ItemSO item = loader.getRandomItem();
        Animation animLeft = animalLeft.getRandomAnimation();
        TraitSO trait = animalRight.getRandomTrait();

        Left objectLeft = new Left(animLeft, item, trait);

        //Creation object right/receiver
        Animation animRight = animalRight.getRandomAnimation();
        Right objectRight = new Right(animRight, item, animalRight);

        //Addition to lists, index random
        if(leftList.Count == 0)
        {
            leftList.Add(objectLeft);
        }else
        {
            leftList.Insert(Random.Range(0, leftList.Count - 1),objectLeft);
        }

        if(rightList.Count == 0)
        {
            rightList.Add(objectRight);
        }else
        {
            rightList.Insert(Random.Range(0, rightList.Count - 1),objectRight);
        }
        
    }
}
