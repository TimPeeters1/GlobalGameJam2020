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

        for (int i = 0; i < objectBrokenStages.Length; i++)
        {
            objectBrokenStages[i].SetActive(false);
        }
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

        StartReset();
        ResetObject();
        base.Interact();

        BrokenObjectManager.Instance.DisableScript(interactableNumber);
    }

}
