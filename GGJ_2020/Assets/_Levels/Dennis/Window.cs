using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
    //private serialized
    [SerializeField] private GameObject[] glassBrokenStages;

    public override void Update()
    {
        base.Update();
        Stages(glassBrokenStages);
    }

    public override void Interact()
    {
        base.Interact();
        StartReset();
        Debug.Log("Window");
    }
}
