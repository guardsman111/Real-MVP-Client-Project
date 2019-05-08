using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Facts : MonoBehaviour
{
    public bool isCredits;
    public Text textBox;
    public string[] facts = { "Your average motor mechanic can earn £18-35'000 a year!", "Vehicle body repairers can earn £15-30'000 a year!", "Skills group can help you find your place in a number of Automotive servicing roles!", "Skills group holds a 82% success rate, above the national average of 72%!" };

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, facts.Length);
        textBox.text = facts[rand];
    }

    private void OnMouseUp()
    {
        if (isCredits)
        {
            SceneManager.LoadScene("MainMenu");
        } else
        {
            SceneManager.LoadScene("Car Repair Screen");
        }
    }
}
