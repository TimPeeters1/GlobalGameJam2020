using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSSystem : Interactable
{
    //private serialized
    [SerializeField] private GameObject[] objectBrokenStages;

    [SerializeField] GameObject plugOn;
    [SerializeField] GameObject plugOff;

    bool isOn;

    public override void Awake()
    {
        plugOn.SetActive(true);
        plugOff.SetActive(false);
        isOn = true;
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

    public void DoPlug()
    {
        if (this.enabled)
        {
            if (isOn)
            {
                plugOff.SetActive(true);
                plugOn.SetActive(false);
                isOn = false;
            }
            else
            {
                plugOff.SetActive(false);
                plugOn.SetActive(true);
                isOn = true;

                Interact();
            }
        }
    }
}
