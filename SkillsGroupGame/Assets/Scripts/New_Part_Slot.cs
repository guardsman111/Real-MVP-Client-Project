using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Part_Slot : MonoBehaviour
{
    public GameObject newPartPrefab;
    public Transform spawn;

    // Creates a new copy of the part type under the spawn point
    private void OnMouseDown()
    {
        GameObject newPart = Instantiate(newPartPrefab, spawn.position, transform.rotation);
        newPart.GetComponent<Part_Script>().emptyPos = spawn;
    }
}
