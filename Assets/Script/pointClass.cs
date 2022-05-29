using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointClass : MonoBehaviour
{
    private RectTransform mainObject;
    public float x { get; set; }
    public float y { get; set; }
    private float spawnC;
    public pointClass()
    {
        x = 0;
        y = 0;
        spawnC = GeneratePoints.spawnCoordinates;
    }
    public pointClass(float x1000,float y1000)
    {
        x = x1000;
        y = y1000;
        spawnC = GeneratePoints.spawnCoordinates;
    }
    void Start()
    {
        mainObject = GetComponent<RectTransform>();
        mainObject.sizeDelta = new Vector2(x*spawnC,y*spawnC*-1);
    }

    void Update()
    {
        if (spawnC != GeneratePoints.spawnCoordinates)
        {
            UpdateScale();
            setCoor();
        }
    }
    void UpdateScale()
    {
        spawnC = GeneratePoints.spawnCoordinates;
    }

    void setCoor()
    {
        mainObject.sizeDelta = new Vector2(x * spawnC, y * spawnC * -1);
    }

}
