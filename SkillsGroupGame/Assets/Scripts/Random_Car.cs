using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Car : MonoBehaviour
{
    public Sprite carBlue;
    public Sprite carGreen;
    public Sprite carRed;
    public Sprite carPurple;
    public Sprite carYellow;

    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new Sprite[] { carBlue, carGreen, carPurple, carRed, carYellow };
        int number = Random.Range(0, 4);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[number];
    }

}
