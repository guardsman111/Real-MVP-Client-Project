using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Completion_Script : MonoBehaviour
{
    public GameObject parent;

    public void WriteResult(int brokenPartsMissed, float TimeTaken)
    {
        this.GetComponent<Text>().text = ("Number of broken parts missed - " + brokenPartsMissed + "\n\nTime taken to effect repairs - " + TimeTaken);
        parent.SetActive(true);
    }
}
