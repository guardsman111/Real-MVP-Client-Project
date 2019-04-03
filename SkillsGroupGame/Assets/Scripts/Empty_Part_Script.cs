using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty_Part_Script : MonoBehaviour
{
    public bool isFull = true;

    //Sets the part slot as full
    public void setFull(bool value)
    {
        isFull = value;
    }
}
