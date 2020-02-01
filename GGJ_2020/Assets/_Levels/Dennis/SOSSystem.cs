using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSSystem : Interactable
{
    //private serialized
    [SerializeField] private GameObject[] objectBrokenStages;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Update()
    {
        if(currentStage == 5)
        {
            return;
        }

        base.Update();
        Stages(objectBrokenStages, true);

        if (currentStage > 1)
        {
            ShipManagement.Instance.TimeActive(false);
        }
    }

    public override void Interact()
    {
        base.Interact();
        StartReset();
        ResetObject();

        ShipManagement.Instance.TimeActive(true);
        BrokenObjectManager.Instance.DisableScript(interactableNumber);
    }
}
