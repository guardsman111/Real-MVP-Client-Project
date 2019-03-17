using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Script : MonoBehaviour
{
    private Camera sceneCamera;
    public Sprite brokenSprite;
    public Transform emptyPos;
    public bool isBroken = false;

    private bool overBin = false;
    public bool canBreak = false;

    // Randomly declares the part broken or leaves it as its default, inspector set value.
    void Start()
    {
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (canBreak)
            CheckBroken();
    }

    public void CheckBroken()
    {
        int r = Random.Range(0, 2);

        if (r >= 1)
            isBroken = true;

        if (isBroken)
            GetComponent<SpriteRenderer>().sprite = brokenSprite;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down" + gameObject.name);
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
        if (overBin)
        {
            Destroy(gameObject, 0.0f);
        }
        else
        {
            transform.position = emptyPos.position;
            emptyPos.gameObject.GetComponent<Empty_Part_Script>().setFull(true);
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
            emptyPos = collision.gameObject.transform;
        }
        Debug.Log(gameObject.name + "Collision");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bin")
        {
            overBin = false;
        }
    }
}
