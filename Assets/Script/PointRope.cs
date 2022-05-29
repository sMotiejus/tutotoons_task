using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer l = gameObject.GetComponent<LineRenderer>();


        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(0, 0, 0));
        int nameString = int.Parse(transform.parent.name);

        if (nameString+1 < GeneratePoints.ropes.Count)
        {
            float dalinti = transform.parent.localScale.x;
            pos.Add(new Vector3(Coordinates(GeneratePoints.ropes[nameString+1].x, GeneratePoints.ropes[nameString].x)/dalinti,
                    Coordinates(GeneratePoints.ropes[nameString + 1].y, GeneratePoints.ropes[nameString].y) / dalinti,
                    Coordinates(GeneratePoints.ropes[nameString + 1].z, GeneratePoints.ropes[nameString].z) / dalinti));
        }

        l.positionCount = pos.Count;

        l.startWidth = 0.2f;
        l.endWidth = 0.2f;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = false;
    }
    private float Coordinates(float a, float b)
    {
        //Abu teigiami
        if(a>0 && b > 0)
        {
            return a - b;
        }

        //Abu neigiami
        if (a < 0 && b < 0 && a > b)
        {
            return (-1*a) - (-1*b);
        }
        if (a < 0 && b < 0 && a < b)
        {
            return -1*((-1 * a) - (-1 * b));
        }

        return 0;
    }
}
