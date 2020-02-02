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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerPickup>())
        {
            if (other.gameObject.GetComponent<PlayerPickup>().currentItem)
            {
                if (other.gameObject.gameObject.GetComponent<PlayerPickup>()
                    .currentItem.GetComponent<FixPickup>().FixableType == ObjectType
                    && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<GeneralBroken>().Interact();
                    Debug.Log("Repaired");
                }
            }

            if (ObjectType == BrokenObjectType.None && Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<GeneralBroken>().Interact();
                Debug.Log("Repaired without object");
            }
        }
    }
}
