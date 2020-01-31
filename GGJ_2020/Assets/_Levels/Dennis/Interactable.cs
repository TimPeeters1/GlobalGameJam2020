using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //private serialized
    [SerializeField] private float repairedToBrokenTime;
    [SerializeField] private float nextBrokenStageTime;
    [SerializeField] private float currentStage = 1;

    //private
    private float currentNextBrokenStageTimer;
    private bool isColliding = false;
    private GameObject[] currentObject;

    public virtual void Start()
    {
        StartReset();
        ResetObject();
    }
    protected void StartReset()
    {
        currentNextBrokenStageTimer = repairedToBrokenTime;
        currentStage = 1;
    }
    private void ResetObject()
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
                Interact();
            }
        }
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
    protected void Stages(GameObject[] objectChanges)
    {
        currentObject = objectChanges;

        //Bij stage 1 is alles onder controle
        if (currentStage == 1)
        {
            ResetObject();
        }
        else if (currentStage == 2)
        {
            ResetObject();
            currentObject[0].SetActive(true);
        }
        else if (currentStage == 3)
        {
            ResetObject();
            currentObject[1].SetActive(true);
        }
        else if (currentStage == 4)
        {
            ResetObject();
            currentObject[2].SetActive(true);
        }
        //Bij stage 5 is het object helemaal kapot
        else if (currentStage == 5)
        {
            Debug.Log("KABOOOOOMMM, you're dead");
            //The thing is broken, the player loses
        }
    }
    public virtual void Interact()
    {
        //Interacting
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
