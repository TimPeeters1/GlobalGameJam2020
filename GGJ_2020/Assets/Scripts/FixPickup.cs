using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPickup : MonoBehaviour
{
    [Tooltip("The Type of Object this Item can fix.")]
    public BrokenObjectType FixableType; //The object type this object can repair.

}
