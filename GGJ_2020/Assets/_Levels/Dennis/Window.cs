using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
    [SerializeField] private int interactableNumber;

    //private serialized
    [SerializeField] private GameObject[] glassBrokenStages;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Update()
    {
        base.Update();
        Stages(glassBrokenStages);
    }
    public override void Interact()
    {
        base.Interact();
        StartReset();
        ResetObject();

        BrokenObjectManager.Instance.DisableScript(interactableNumber);
        Debug.Log("Window");
    }
}
