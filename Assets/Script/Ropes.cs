using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer l = gameObject.GetComponent<LineRenderer>();


        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(-175, -175,0));
        pos.Add(new Vector3(175, -175,0));

        l.positionCount = pos.Count;

        l.startWidth = 0.3f;
        l.endWidth = 0.3f;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = false;
    }

}
