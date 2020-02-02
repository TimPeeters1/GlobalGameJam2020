using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("General Stuff")]
    //protected
    [SerializeField] protected int interactableNumber;
    protected float currentStage = 1;
    protected bool isColliding = false;

    //private serialized
    [SerializeField] private float repairedToBrokenTime;
    [SerializeField] private float nextBrokenStageTime;
    [SerializeField] private bool trashBin = false;
    [SerializeField] private TrashBin trashScript;

    //private
    private float currentNextBrokenStageTimer;
    private GameObject[] currentObject;

    private void OnEnable()
    {
        currentObject[currentObject.Length - 1].SetActive(false);
    }

    public virtual void Awake()
    {
        StartReset();
        ResetObject();
    }
    protected void StartReset()
    {
        currentNextBrokenStageTimer = repairedToBrokenTime;
        currentStage = 1;
    }
    protected void ResetObject()
    {
        if(currentObject != null)
        {
            for (int i = 0; i < currentObject.Length; i++)
            {
                currentObject[i].SetActive(false);
            }
        }
    }
    public virtual void Update()
    {
        CheckInput();
        StageTimer();
    }
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isColliding = false;
        }
    }
    private void CheckInput()
    {
        if (isColliding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Interact();
            }
        }
    }
    public virtual void Interact()
    {
        //Interacting
        if (!trashBin)
        {
            trashScript.AddTrash();
        }

        currentObject[currentObject.Length - 1].SetActive(true);
        ProblemList.Instance.UpdateList(interactableNumber, 1);
    }
    private void StageTimer()
    {
        currentNextBrokenStageTimer = Timer(currentNextBrokenStageTimer);

        if(currentNextBrokenStageTimer <= 0 || repairedToBrokenTime <= 0)
        {
            currentNextBrokenStageTimer = nextBrokenStageTime;
            currentStage++;
        }
    }
    protected void Stages(GameObject[] objectChanges, bool lastStage)
    {
        currentObject = objectChanges;

        //Bij stage 1 is alles onder controle
        if (currentStage == 0)
        {
            ProblemList.Instance.UpdateList(interactableNumber, 1);
        }
        if (currentStage == 1)
        {
            ProblemList.Instance.UpdateList(interactableNumber, 1);
        }
        else if (currentStage == 2)
        {
            currentObject[0].SetActive(true);
            ProblemList.Instance.UpdateList(interactableNumber, 2);
        }
        else if (currentStage == 3)
        {
            currentObject[0].SetActive(false);
            currentObject[1].SetActive(true);
            ProblemList.Instance.UpdateList(interactableNumber, 3);
        }
        else if (currentStage == 4)
        {
            currentObject[1].SetActive(false);
            currentObject[2].SetActive(true);
            ProblemList.Instance.UpdateList(interactableNumber, 4);
        }
        //Bij stage 5 is het object helemaal kapot
        else if (currentStage == 5 && lastStage)
        {
            Debug.Log("KABOOOOOMMM, you're dead");
            currentObject[2].SetActive(false);
            ShipManagement.Instance.GameOver();
            //The thing is broken, the player loses
        }
        else if(currentStage == 6)
        {

        }
    }
    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
