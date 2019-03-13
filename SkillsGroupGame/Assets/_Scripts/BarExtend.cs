using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarExtend : MonoBehaviour
{
    Transform t;
    Vector3 grow = new Vector3(0.5f, 0.0f, 0.0f);

    private void Start()
    {
        t = this.transform;
    }

    public void PointerEnter()
    {
        Debug.Log("Triggered!");
        Grow();
    }

    public void PointerExit()
    {
        Shrink();
    }

    public void Grow()
    {
        Debug.Log("Grow!");

        while (t.localScale.x < 25.0f)
        {
            Debug.Log("lol");
            t.localScale += grow;
            new WaitForSeconds(0.5f);
        }
        
    }

    public void Shrink()
    {
        Debug.Log("Shrink!");

        while (t.localScale.x > 1f)
        {
            t.localScale -= grow;
            new WaitForSeconds(0.5f);
        }

        
    }

  
}
