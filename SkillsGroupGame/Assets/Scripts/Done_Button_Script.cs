using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Button_Script : MonoBehaviour
{
    public GameObject partsParent;
    private Part_Script[] partsArray;
    private int partsBroken = 0;

    public Completion_Script display;

    public void CheckParts()
    {
        partsArray = partsParent.GetComponentsInChildren<Part_Script>();
        partsBroken = 0;
        foreach (Part_Script part in partsArray)
        {
            if (part.isBroken == true)
            {
                partsBroken += 1;
            }
        }
        display.WriteResult(partsBroken, Time.timeSinceLevelLoad);
    }

    private void OnMouseUp()
    {
        CheckParts();
    }
}
