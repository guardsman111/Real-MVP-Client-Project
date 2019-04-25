using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Completion_Script : MonoBehaviour
{
    public GameObject parent;

    public static float globalScore = 0;
    public static float brokenPartsChanged = 0;
    public static float needlessPartsChanged = 0;
    public Sound_Manager soundManager;

    public void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sound_Manager>();
    }

    //Writes the results to the ingame canvas and displays it too player
    public void WriteResult(int brokenPartsMissed, float TimeTaken)
    {
        if (TimeTaken <= brokenPartsChanged * 5)
        {
            globalScore = globalScore * 1.2f;
        }
        this.GetComponent<Text>().text = ("Number of broken parts changed - " + brokenPartsChanged + "\n\nNumber of non-faulty parts changed - " + needlessPartsChanged + "\n\nNumber of repairs missed - " + brokenPartsMissed + "\n\nTime taken to effect repairs - " + TimeTaken + "\n\nTotal Score - \n" + (int)globalScore + " out of " + ((brokenPartsChanged + brokenPartsMissed) * 100) * 1.2);

        if (brokenPartsMissed > 0)
            soundManager.PlayLeaveFail();
        else
            soundManager.PlayLeave();

        parent.SetActive(true);
    }

    //Writes missing parts to the screen when the player has left empty part slots
    public void MissingParts()
    {
        this.GetComponent<Text>().text = ("MissingParts! Fill all parts slots!");
        parent.SetActive(true);
        Invoke("MissingPartsGo", 1.0f);
    }

    //Clears the missing parts screen
    public void MissingPartsGo()
    {
        parent.SetActive(false);
    }
}
