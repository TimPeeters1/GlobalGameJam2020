﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : Interactable
{
    //private serialized
    [SerializeField] private GameObject[] oxygenBrokenTank;
    //private
    private bool destroyed = false;
    private OxygenTankManager oxygenTankManager;
    
    public override void Awake()
    {
        base.Awake();
        
        oxygenTankManager = GetComponentInParent<OxygenTankManager>();
    }
    public override void Update()
    {
        if (currentStage == 5 && !destroyed)
        {
            destroyed = true;
            
            oxygenBrokenTank[2].SetActive(false);
            oxygenBrokenTank[3].SetActive(true);

            for (int i = 0; i < nextPhaseParticle.Length; i++)
            {
                nextPhaseParticle[i].SetActive(false);
            }

            ProblemList.Instance.UpdateList(interactableNumber, 5);
            oxygenTankManager.OxygenTankDestroyed();
            return;
        }
        else if (!destroyed)
        {
            base.Update();
            Stages(oxygenBrokenTank, false);
        }
    }
    public override void Interact()
    {
        if (destroyed)
        {
            return;
        }

        base.Interact();
        StartReset();
        ResetObject();
        
        BrokenObjectManager.Instance.DisableScript(interactableNumber);
    }
}