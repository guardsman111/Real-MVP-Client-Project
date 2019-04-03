using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Completion_Script : MonoBehaviour
{
    public GameObject parent;

    public static float globalScore = 0;
    public static int brokenPartsChanged = 0;
    public static int partsNotReplaced = 0;
    public static int needlessPartsChanged = 0;

    public void WriteResult(int brokenPartsMissed, float TimeTaken)
    {
        if (TimeTaken >= (brokenPartsChanged* 5))
        {
            globalScore += globalScore * 0.2f;
        }
        this.GetComponent<Text>().text = ("Number of broken parts changed - " + brokenPartsChanged + "\n\nNumber of non-faulty parts changed - " + needlessPartsChanged + "\n\nNumber of repairs missed - " + partsNotReplaced + "\n\nTime taken to effect repairs - " + TimeTaken + "\n\nTotal Score - " + globalScore);
        parent.SetActive(true);
    }

    public void MissingParts()
    {
        this.GetComponent<Text>().text = ("MissingParts!");
        parent.SetActive(true);
        Invoke("MissingPartsGo", 1.0f);
    }

    public void MissingPartsGo()
    {
        parent.SetActive(false);
    }
}
