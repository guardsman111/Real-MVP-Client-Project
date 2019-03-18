using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarExtend : MonoBehaviour
{
    RectTransform t;
    public GameObject point;
    Vector2 grow = new Vector2(10f, 0.0f);

    private bool growing = false;
    private bool shrinking = false;

    private void Start()
    {
        t = this.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (growing)
        {
            if (t.sizeDelta.x < 700.0f)
                t.sizeDelta += grow;
            else
                growing = false;
        }
        else if (shrinking)
        {
            if (t.sizeDelta.x > 280.0f)
                t.sizeDelta -= grow;
            else
                shrinking = false;
        }
    }

    public void PointerEnter()
    {
        Grow();
    }

    public void PointerExit()
    {
        Shrink();
    }

    public void Grow()
    {
        point.SetActive(true);
        if (t.sizeDelta.x < 500.0f)
        {
            growing = true;
        }

    }


    public void Shrink()
    {
        point.SetActive(false);
        if (t.sizeDelta.x > 280.0f)
        {
            shrinking = true;
        }
    }

  
}
