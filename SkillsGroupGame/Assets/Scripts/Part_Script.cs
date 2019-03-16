using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Script : MonoBehaviour
{
    private Camera camera;
    public bool isBroken = false;

    // Start is called before the first frame update
    // Randomly declares the part broken or leaves it as its default, inspector set value.
    void Start()
    {
        int r = Random.Range(0,2);

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (r >= 1)
            isBroken = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down" + gameObject.name);
    }

    private void OnMouseDrag()
    {
        Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
        transform.position = camera.ScreenToWorldPoint(Input.mousePosition) - offset;
    }

}
