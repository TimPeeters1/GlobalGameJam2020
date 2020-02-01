using System.Collections;
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
        ResetObject();
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