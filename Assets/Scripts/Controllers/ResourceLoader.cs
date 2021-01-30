using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{

    [SerializeField]
    private static AnimalSO[] animals;
    [SerializeField]
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

    private void Awake()
    {
        LoadResources();
    }
    private void LoadResources()
    {
        animals = Resources.LoadAll<AnimalSO>("ScriptableObjects/Animals");
        Debug.Log("Total amount of animals = " + animals.Length);
        items = Resources.LoadAll<ItemSO>("ScriptableObjects/Items/");
        Debug.Log("Total amount of items = " + animals.Length);
    }

    public AnimalSO getRandomAnimal()
    {
        return animals[Random.Range(0, animals.Length)];
    }


    public ItemSO getRandomItem()
    {
        if (items == null) Debug.Log("Items is null!");
        else if (items.Length == 0) Debug.Log("Items is empty!");
        return items[Random.Range(0, items.Length)];
    }
}
