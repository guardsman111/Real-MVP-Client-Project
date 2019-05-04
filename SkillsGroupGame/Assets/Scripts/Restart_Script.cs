using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Script : MonoBehaviour
{
    //Restarts the Scene
    public void Restart()
    {
        Completion_Script.globalScore = 0;
        Completion_Script.brokenPartsChanged = 0;
        Completion_Script.needlessPartsChanged = 0;
        SceneManager.LoadScene("AutomotiveFacts");
    }
}
