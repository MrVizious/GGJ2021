using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{

    private static AnimalSO[] animals;
    private static ItemSO[] items;

    #region SINGLETON PATTERN
    public static ResourceLoader _instance;
    public static ResourceLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ResourceLoader>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("ResourceLoader");
                    _instance = container.AddComponent<ResourceLoader>();
                }
            }

            return _instance;
        }
    }
    #endregion

    private void LoadResources()
    {
        animals = (AnimalSO[])Resources.LoadAll("ScriptableObjects/Animals");
        items = (ItemSO[])Resources.LoadAll("ScriptableObjects/Items");
    }

    public AnimalSO getRandomAnimal()
    {
        return animals[Random.Range(0, animals.Length - 1)];
    }
    public ItemSO getRandomItem()
    {
        return items[Random.Range(0, items.Length - 1)];
    }
}
