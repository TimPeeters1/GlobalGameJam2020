using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BrokenObjectType
{
    Window,
    OxygenSystem,
    NavigationSystem,
    FuelTank,
    Database,
    None
}


public class InteractionSystem : MonoBehaviour
{
    public BrokenObjectType ObjectType;
    public ParticleSystem repairSmoke;

    private bool isColliding = false;
    private GameObject collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerPickup>())
        {
            isColliding = true;
            collider = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerPickup>())
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            if (collider.GetComponent<PlayerPickup>().currentItem)
            {
                if (collider.gameObject.GetComponent<PlayerPickup>().currentItem.GetComponent<FixPickup>().FixableType == ObjectType
                    && Input.GetKeyDown(KeyCode.Mouse0))
                {

                    if (GetComponent<GeneralBroken>())
                    {
                        GetComponent<GeneralBroken>().Interact();
                    }
                    if (GetComponent<OxygenTank>())
                    {
                        GetComponent<OxygenTank>().Interact();
                    }

                    Debug.Log("Repaired");
                    repairSmoke.Play();

                    collider.gameObject.GetComponent<PlayerPickup>().currentItem.SetActive(false);
                }
            }

            if ((ObjectType == BrokenObjectType.None || ObjectType == BrokenObjectType.Database) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<GeneralBroken>().Interact();
                Debug.Log("Repaired without object");

            }

            if (ObjectType == BrokenObjectType.NavigationSystem && Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<SOSSystem>().DoPlug();

            }
            
        }
    }
}