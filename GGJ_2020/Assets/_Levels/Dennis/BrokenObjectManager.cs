﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObjectManager : MonoBehaviour
{
    [SerializeField] private float nextEventTime;
    [SerializeField] private bool[] interactableActive;
    [SerializeField] private Interactable[] interactables;

    private int randomNumber;
    private float currentNextEventTimer;
    private bool objectFalse;

    #region Singleton
    private static BrokenObjectManager instance;
    private void Awake()
    {
        instance = this;
    }

    public static BrokenObjectManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BrokenObjectManager();
            }

            return instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        currentNextEventTimer = nextEventTime;
        
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].enabled = false;
            interactableActive[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        NextEventChecker();
    }

    private void NextEventChecker()
    {
        currentNextEventTimer = Timer(currentNextEventTimer);

        if(currentNextEventTimer <= 0)
        {
            currentNextEventTimer = Random.Range(nextEventTime * 0.75f, nextEventTime);
            randomNumber = Random.Range(0, interactables.Length);

            for (int i = 0; i < interactables.Length; i++)
            {
                if(interactableActive[i] == false)
                {
                    objectFalse = true;
                    break;
                }
                else
                {
                    objectFalse = false;
                }
            }

            while (interactables[randomNumber].enabled == true && objectFalse)
            {
                randomNumber = Random.Range(0, interactables.Length);
            }

            interactables[randomNumber].enabled = true;
            interactableActive[randomNumber] = true;
        }
    }
    public void DisableScript(int interactableNumber)
    {
        interactables[interactableNumber].enabled = false;
        interactableActive[interactableNumber] = false;
    }
    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
