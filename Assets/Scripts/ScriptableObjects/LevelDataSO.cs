using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public UnityEvent onLeftIndexUpdated, onRightIndexUpdated, onCorrectMatch, onWrongMatch, onStorageUpdate;
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

        //Check that no other same animal is in right list with same item
        if (rightList.IndexOf(objectRight) >= 0) return false;


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
            int randomIndex = Random.Range(0, leftList.Count - 1);
            leftList.Insert(randomIndex, newLeft);
            if (leftIndex >= randomIndex)
            {
                leftIndex++;
            }
        }
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
            int randomIndex = Random.Range(0, rightList.Count - 1);
            rightList.Insert(Random.Range(0, rightList.Count - 1), newRight);
            if (rightIndex >= randomIndex)
            {
                rightIndex++;
            }
        }
    }

    public void RotateLeft(int amountToRotate)
    {
        if (amountToRotate == 0) return;

        // Update index depending on value (positive or negative)
        leftIndex = mod(leftIndex + amountToRotate, leftList.Count);

        //Raise event onLeftIndexUpdated
        onLeftIndexUpdated.Invoke();

    }
    public void RotateRight(int amountToRotate)
    {
        if (amountToRotate == 0) return;

        rightIndex = mod(rightIndex + amountToRotate, rightList.Count);

        //Raise event onRightIndexUpdated
        onRightIndexUpdated.Invoke();
    }

    public bool Match(int storageIndex)
    {
        // Does the trait and item on the left match the trait and item of the right?
        // TODO: Delete both, left from storage and right from list
        TraitSO traitLeft = storaged[storageIndex].trait;
        ItemSO itemLeft = storaged[storageIndex].item;

        List<TraitSO> traitsRight = rightList[rightIndex].animal.traits;
        ItemSO itemRight = rightList[rightIndex].item;
        bool conditionMatch = false;

        //If item isnt equal Wrong Match
        if (!itemLeft.Equals(itemRight))//Item not correct
        {
            conditionMatch = false;
        }
        else//Item correct
        {
            for (int count = 0; count < traitsRight.Count; count++)
            {
                if (traitsRight[count] == traitLeft)//Trait found in rightAnimal
                {
                    conditionMatch = true;
                }
            }
        }
        //Trait not found in rightAnimal
        if (conditionMatch)
        {
            onCorrectMatch.Invoke();
        }
        else
        {
            onWrongMatch.Invoke();
        }

        //Delete left and right
        RemoveFromStorage(storageIndex);
        RemoveFromRigth(rightList[rightIndex]);
        return conditionMatch;
    }

    public void StorageAction(int storageIndex)
    {
        // If the storage index is full, match
        // if not, storage current left instance and update shit
        // Invoke event updating storage graphics 
        if (storaged[storageIndex] != null)
        {
            Match(storageIndex);
        }
        else
        {
            storaged[storageIndex] = leftList[leftIndex];
            RemoveFromLeft(leftList[leftIndex]);
        }
        onStorageUpdate.Invoke();

    }

    public int mod(int x, int m)
    {
        return (x % m + m) % m;
    }


    public void RemoveFromStorage(int indexStorage)
    {
        storaged[indexStorage] = null;
    }
    public void RemoveFromLeft(Left leftToRemove)
    {
        leftList.Remove(leftToRemove);
        RotateLeft(-1);
    }

    public void RemoveFromRigth(Right rigthToRemove)
    {
        rightList.Remove(rigthToRemove);
        RotateRight(-1);
    }

    public Left getCurrentLeft()
    {
        return leftList[leftIndex];
    }

    public Right getCurrentRight()
    {
        return rightList[rightIndex];
    }

    public Left getItemStoraged(int storageIndex)
    {
        return storaged[storageIndex];
    }
}
