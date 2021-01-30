using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelDataSO : ScriptableObject
{
    private List<Left> leftList;
    private List<Right> rightList;
    private int leftIndex, rightIndex = 0;
    private Left[] storaged;

    private void Awake()
    {
        leftList = new List<Left>();
        rightList = new List<Right>();
        storaged = new Left[2];
    }


    public bool AddCombination(AnimalSO leftAnimal, AnimalSO rightAnimal, ItemSO item)
    {

        // TODO: Check that no other same animal is in right list with same item
        if (leftAnimal.Equals(rightAnimal))
        {
            return false;
        }

        Animation animLeft = leftAnimal.getRandomAnimation();
        TraitSO trait = rightAnimal.getRandomTrait();

        Left objectLeft = new Left(animLeft, item, trait);

        //Creation object right/receiver
        Animation animRight = rightAnimal.getRandomAnimation();
        Right objectRight = new Right(animRight, item, rightAnimal);


        if (rightList.Count == 0)
        {
            rightList.Add(objectRight);
        }
        else
        {
            rightList.Insert(Random.Range(0, rightList.Count - 1), objectRight);
        }

        return true;

    }

    private void AddToLeft(Left newLeft)
    {
        //Addition to lists, index random
        if (leftList.Count == 0)
        {
            leftList.Add(newLeft);
        }
        else
        {
            leftList.Insert(Random.Range(0, leftList.Count - 1), newLeft);
        }
        // TODO: Update index
    }

    private void AddToRight(Right newRight)
    {
        //Addition to lists, index random
        if (rightList.Count == 0)
        {
            rightList.Add(newRight);
        }
        else
        {
            rightList.Insert(Random.Range(0, rightList.Count - 1), newRight);
        }
        // TODO: Update index
    }

    public void RotateLeft(int amountToRotate)
    {
        if (amountToRotate == 0) return;

        // TODO: Update index depending on value (positive or negative)
        // if positive: newIndex = (currentIndex + amountToRotate) % list.count
        // if negative: newIndex = (currentIndex + amountToRotate + list.count) % list.count

        // TODO: Raise event onLeftIndexUpdated
    }
    public void RotateRight(int amountToRotate)
    {
        if (amountToRotate == 0) return;

        // TODO: Update index depending on value (positive or negative)
        // if positive: newIndex = (currentIndex + amountToRotate) % list.count
        // if negative: newIndex = (currentIndex + amountToRotate + list.count) % list.count

        // TODO: Raise event onRightIndexUpdated
    }

    public bool Match(int storageIndex)
    {
        // TODO: Does the trait and item on the left match the trait and item of the right?
        // TODO: Delete both, left from storage and right from list

        // TODO: Raise event onCorrectMatch or onWrongMatch
        return false;
    }

    public void StorageAction(int storageIndex)
    {
        // TODO: If the storage index is full, match
        // if not, storage current left instance and update shit
    }
}
