using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable
{
    [Header("Trash")]
    //private serialized
    [SerializeField] private int maxTrash;
    [SerializeField] private float trashMaxY;
    [SerializeField] private float trashMinY;
    [SerializeField] private GameObject trash;

    //private
    private int trashCount;
    private float increaseY;

    public override void Awake()
    {
        base.Awake();
        increaseY = ((trashMaxY - trashMinY) / maxTrash);

        Debug.Log(increaseY);
    }
    public override void Update()
    {
        if (currentStage == 5)
        {
            return;
        }

        base.Update();
    }
    public override void Interact()
    {
        base.Interact();
        StartReset();
        ResetObject();

        trashCount = 0;
        trash.transform.position = new Vector3(trash.transform.position.x, trashMinY, trash.transform.position.z);
    }

    public void AddTrash()
    {
        trashCount++;

        trash.transform.position = new Vector3(trash.transform.position.x, trash.transform.position.y + increaseY, trash.transform.position.z);
        if(trashCount == maxTrash)
        {
            Debug.Log("Trashcan overloaded");
        }
    }
}
