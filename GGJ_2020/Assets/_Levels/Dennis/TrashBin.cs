using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable
{
    [Header("Trash")]
    //private serialized
    [SerializeField] private int maxTrash;
    [SerializeField] private GameObject[] trash;

    //private
    private int trashCount;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Update()
    {
        base.Update();

        if(trashCount > (maxTrash * 0.75f))
        {
            ProblemList.Instance.UpdateList(interactableNumber, 4);
            trash[2].SetActive(true);
        }
        else if(trashCount > (maxTrash * 0.50f))
        {
            ProblemList.Instance.UpdateList(interactableNumber, 3);
            trash[1].SetActive(true);
        }
        else if (trashCount > (maxTrash * 0.25f))
        {
            ProblemList.Instance.UpdateList(interactableNumber, 2);
            trash[0].SetActive(true);
        }
        else
        {
            ProblemList.Instance.UpdateList(interactableNumber, 1);
            trash[0].SetActive(false);
            trash[1].SetActive(false);
            trash[2].SetActive(false);
        }
    }
    public override void Interact()
    {
        trashCount = 0;
    }

    public void AddTrash()
    {
        trashCount++;

        if(trashCount == maxTrash)
        {
            Debug.Log("Trashcan overloaded");
            ShipManagement.Instance.GameOver();
        }
    }
}
