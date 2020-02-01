using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankManager : MonoBehaviour
{
    //private serialized
    [SerializeField] private OxygenTank[] oxygenTank;

    //private 
    private int maxOxygenTank;
    private int oxygenTankDestroyed = 0;

    private void Start()
    {
        maxOxygenTank = oxygenTank.Length;
    }

    public void OxygenTankDestroyed()
    {
        oxygenTankDestroyed++;

        if(oxygenTankDestroyed >= maxOxygenTank)
        {
            Debug.Log("Oxygen level to low, Game Over");
        }
    }
}
