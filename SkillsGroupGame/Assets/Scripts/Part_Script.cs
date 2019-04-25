using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Script : MonoBehaviour
{
    private Camera sceneCamera;
    public Sprite brokenSprite;
    public AudioSource brokenNoise;
    public Transform emptyPos;
    public bool isBroken = false;

    public Sound_Manager soundManager;
    private bool overBin = false;
    public bool canBreak = false;

    // Randomly declares the part broken or leaves it as its default, inspector set value.
    void Start()
    {
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sound_Manager>();

        if (canBreak)
            CheckBroken();
    }

    public void CheckBroken()
    {
        int r = Random.Range(0, 2);

        if (r >= 1)
            isBroken = true;

        if (isBroken)
        {
            if (gameObject.tag == "Alternator")
            {
                soundManager.ChangeArrive(brokenNoise);
                soundManager.PlayArrive();
            }
            else if (gameObject.tag == "Gear Box")
                brokenNoise.Play();
            else
                GetComponent<SpriteRenderer>().sprite = brokenSprite;
        }

        else if (gameObject.tag == "Alternator")
            soundManager.PlayArrive();
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down" + gameObject.name);
        if (emptyPos.name != "Spawn")
            soundManager.PartChange();
    }

    // Moves the part with the mouse
    private void OnMouseDrag()
    {
        Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
        transform.position = sceneCamera.ScreenToWorldPoint(Input.mousePosition) - offset;
    }

    // Drops the part
    private void OnMouseUp()
    {
        //Deletes part and updates scores if over the bin, else returns part to its position
        if (overBin)
        {
            if (isBroken)
            {
                Completion_Script.globalScore += 100;
                Completion_Script.brokenPartsChanged += 1;
            }
            else
            {
                Completion_Script.globalScore -= 100;
                Completion_Script.needlessPartsChanged += 1;
            }
            Destroy(gameObject, 0.0f);
        }
        else
        {
            transform.position = emptyPos.position;
            emptyPos.gameObject.GetComponent<Empty_Part_Script>().setFull(true);
            soundManager.PartChange();
        }
    }

    // Declares what the part is being held over
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bin")
        {
            overBin = true;
            emptyPos.gameObject.GetComponent<Empty_Part_Script>().setFull(false);
        }
        else if (collision.gameObject.tag == gameObject.tag)
        {
            // If part slot is empty
            if (!collision.gameObject.GetComponent<Empty_Part_Script>().isFull)
            {
                //Prevents the part slot from being filled by other parts of the same type passing over it
                if (emptyPos.gameObject.GetComponent<Empty_Part_Script>() != null)
                    emptyPos.gameObject.GetComponent<Empty_Part_Script>().setFull(false);
                emptyPos = collision.gameObject.transform;
            }
        }
        Debug.Log(gameObject.name + "Collision");
    }

    // Registers leaving the bin area
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bin")
        {
            overBin = false;
        }
    }
}
