using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 home = new Vector3(0, 0, 0);
    private Vector3 mousePosition;

    [SerializeField] private bool simplifyLine = false;
    [SerializeField] private float simplifyTolerance = 0.02f;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) //Or use GetKey with key defined with mouse button
        {
            float dist = Vector3.Distance(home, mousePosition);

            Debug.Log(dist);
            if (dist < 5 && dist > -5)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 10;
                if (line.positionCount < 2)
                {
                    line.positionCount = 2;
                    line.SetPosition(0, mousePosition);
                    home = line.GetPosition(0);
                }
                line.SetPosition(line.positionCount - 1, mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (simplifyLine)
            {
                line.Simplify(simplifyTolerance);
            }



            gameObject.GetComponent<EdgeCollider2D>().points = new Vector2[] { (line.GetPosition(0) - line.GetPosition(0)), (line.GetPosition(1) - line.GetPosition(0))};

            enabled = false; //Making this script stop
        }
    }

    public void SetHome(Vector3 position)
    {

    }
}
