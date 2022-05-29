using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneratePoints : MonoBehaviour
{
    public static GameObject main;
    public static bool Good;
    public static List<string> eile = new List<string>();
    public GameObject point;
    public GameObject rope;
    public static List<int> pointXY = new List<int>();
    public static List<Vector3> ropes = new List<Vector3>();
    private RectTransform mainObject;
    public static float spawnCoordinates;
    public static List<string> sequence;
    public static bool restart;

    private void Start()
    {
        main = gameObject;
        Good = true;
        pointXY = LoadJson.levels.levels[MainMenu.selectedLevel].level_data;
        sequence = new List<string>();
        restart = false;
    }

    private void Update()
    {
        if (getCanvasSize.changed)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            mainObject = GetComponent<RectTransform>();
            spawnCoordinates = mainObject.rect.size.x / (float)1001f;
            ropes.Clear();
            getCanvasSize.changed = false;
            sequence = new List<string>();
            spawnPoints();
            restart = true;
        }
    }
    void spawnPoints()
    {
        for(int i = 0; i < pointXY.Count / 2; i++)
        {
            sequence.Add("" + i);
            AddPoint(i);
            AddRope(i);
        }
        for (int i = pointXY.Count/2; i < pointXY.Count; i++)
        {
            RopeCoordinates(i);
        }
    }
    void AddRope(int i)
    {
        ropes.Add(new Vector3(pointXY[i * 2] * spawnCoordinates, -1 * pointXY[i * 2 + 1] * spawnCoordinates, 0));
        var ropeVar = Instantiate(rope, new Vector3(0, 0, -3), Quaternion.identity);
        ropeVar.transform.SetParent(transform, false);
        int nameRope = i + pointXY.Count / 2;
        ropeVar.name = "" + nameRope;
    }

    void AddPoint(int i)
    {
        var pointVar = Instantiate(point, new Vector3(pointXY[i * 2] * spawnCoordinates, -1 * pointXY[i * 2 + 1] * spawnCoordinates, -5), Quaternion.identity);
        pointVar.transform.SetParent(transform, false);
        pointVar.name = "" + i;
        int nr = i + 1;
        pointVar.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "" + nr;
    }

    void RopeCoordinates(int i)
    {
        if(i+1 < pointXY.Count)
        {

            LineRenderer l = transform.Find(i.ToString()).GetComponent<LineRenderer>();
            List<Vector3> pos = new List<Vector3>();
            pos.Add(ropes[i - pointXY.Count / 2]);
            pos.Add(ropes[i + 1 - pointXY.Count / 2]);

            l.positionCount = pos.Count;

            l.startWidth = 0.2f;
            l.endWidth = 0.2f;
            l.SetPositions(pos.ToArray());
            l.useWorldSpace = false;
        }
        else
        {
            LineRenderer l = transform.Find(i.ToString()).GetComponent<LineRenderer>();
            List<Vector3> pos = new List<Vector3>();
            pos.Add(ropes[0]);
            pos.Add(ropes[i - pointXY.Count / 2]);
            

            l.positionCount = pos.Count;

            l.startWidth = 0.2f;
            l.endWidth = 0.2f;
            l.SetPositions(pos.ToArray());
            l.useWorldSpace = false;
        }
       
    }
}
