using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Button_Script : MonoBehaviour
{
    public GameObject partsParent;
    private Empty_Part_Script[] partsArray;
    private int partsBroken = 0;

    public Completion_Script display;

    private bool allPartsOk = true;

    public void CheckParts()
    {
        partsArray = partsParent.GetComponentsInChildren<Empty_Part_Script>();
        partsBroken = 0;
        foreach (Empty_Part_Script part in partsArray)
        {
            if (part.isFull == false)
            {
                allPartsOk = false;
            }
        }
        if (allPartsOk == true)
        {
            display.WriteResult(partsBroken, Time.timeSinceLevelLoad);
        }
        else
        {
            allPartsOk = true;
            display.MissingParts();
        }
    }

    private void OnMouseUp()
    {
        CheckParts();
    }
}
