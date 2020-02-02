using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionSystem))]
public class GeneralBroken : Interactable
{
    //private serialized
    [SerializeField] private GameObject[] objectBrokenStages;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Update()
    {
        if (currentStage == 5)
        {
            return;
        }

        base.Update();
        Stages(objectBrokenStages, true);
    }
    public override void Interact()
    {

        base.Interact();
        StartReset();
        ResetObject();

        BrokenObjectManager.Instance.DisableScript(interactableNumber);
    }

}
