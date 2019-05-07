using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Button_Script : MonoBehaviour
{
    public GameObject partsParent;
    private Empty_Part_Script[] partsArray;
    private Part_Script[] partsArray2;
    private int partsBroken = 0;

    public Completion_Script display;
    public AudioSource click;
    public GameObject car;

    private bool allPartsOk = true;


    // Checks all parts on the screen to see if they are broken, and checks that no part slots are empty
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
        partsArray2 = partsParent.GetComponentsInChildren<Part_Script>();
        foreach (Part_Script part in partsArray2)
        {
            if (part.isBroken)
            {
                partsBroken += 1;
            }
        }
        if (allPartsOk == true)
        {
            car.GetComponent<Animator>().SetBool("Arrived", false);
            display.WriteResult(partsBroken, Time.timeSinceLevelLoad);
            click.Play();
        }
        else
        {
            allPartsOk = true;
            display.MissingParts();
            click.Play();
        }
    }

    private void OnMouseUp()
    {
        CheckParts();
    }
}
