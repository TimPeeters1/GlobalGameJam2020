using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    //[SerializeField] private float timeBetweenPickUps = 10f;
    //private bool isSpawning = false;
    //public GameObject[] pickUp;
    //public Transform[] spawnPoints;

    //private serialized
    [SerializeField] private int itemsActive;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private bool[] objectsActive;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Vector3[] spawnLocation;

    //private 
    private int maxItemsActive;
    private int currentObjectsActive;
    private int randomNumber;
    private float currentTime;

    void Start()
    {
        //StartCoroutine(SpawnPickUp());
        currentObjectsActive = itemsActive;
        maxItemsActive = objects.Length;
        currentTime = timeBetweenSpawns;

        for (int i = 0; i < maxItemsActive; i++)
        {
            objects[i].SetActive(false);
            objectsActive[i] = false;
            spawnLocation[i] = objects[i].transform.position;
        }

        for (int i = 0; i < itemsActive; i++)
        {
            randomNumber = Random.Range(0, maxItemsActive);
            objects[randomNumber].transform.position = spawnLocation[randomNumber];
            objects[randomNumber].SetActive(true);
            objectsActive[randomNumber] = true;
        }

    }

    private void Update()
    {
        currentTime = Timer(currentTime);

        if(currentTime <= 0)
        {
            currentTime = timeBetweenSpawns;

            randomNumber = Random.Range(0, maxItemsActive);
            objects[randomNumber].transform.position = spawnLocation[randomNumber];
            objects[randomNumber].SetActive(true);
            objectsActive[randomNumber] = true;
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
