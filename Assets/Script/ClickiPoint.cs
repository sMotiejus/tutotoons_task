using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ClickiPoint : MonoBehaviour
{
    [SerializeField] private float animationDuration = 5f;

    public Sprite BlueGem;
    public Animator Animator;
    private Vector3[] linePoints = new Vector3[4];

    void Update()
    {
        if (GeneratePoints.eile.Count > 0)
        {
            if (GeneratePoints.Good == true && GeneratePoints.eile[0] == transform.name)
            {
                GeneratePoints.eile.Remove(GeneratePoints.eile[0]);
                GeneratePoints.Good = false;
                int nr = int.Parse(name);
                if (nr > 0)
                {
                    int ropeName = nr - 1 + GeneratePoints.pointXY.Count / 2;
                    LineRenderer lr = transform.parent.transform.Find(ropeName.ToString()).GetComponent<LineRenderer>();
                    lr.enabled = true;

                    linePoints[0] = lr.GetPosition(0);
                    linePoints[1] = lr.GetPosition(1);
                    StartCoroutine(AnimateLine(lr, 0));
                }
                if (nr + 1 == GeneratePoints.pointXY.Count / 2)
                {
                    int ropeName = nr + GeneratePoints.pointXY.Count / 2;
                    LineRenderer lr = transform.parent.transform.Find(ropeName.ToString()).GetComponent<LineRenderer>();
                    lr.enabled = true;
                    linePoints[2] = lr.GetPosition(0);
                    linePoints[3] = lr.GetPosition(1);
                    StartCoroutine(AnimateLine(lr, 2));
                }
            }
        }
        
    }
    public void ChangeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BlueGem;
        Animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        string nameOfThisObject = transform.name;
        if(GeneratePoints.sequence.Count>0)
        {
            if (GeneratePoints.sequence[0].CompareTo(nameOfThisObject)==0)
            {
                Animator.SetBool("fadeOut", true);
                ChangeSprite();
                GeneratePoints.sequence.Remove(nameOfThisObject);
                int nr = int.Parse(name);
                if (nr > 0)
                {
                    GeneratePoints.eile.Add(nameOfThisObject);
                }
            }
        }
    }

    private IEnumerator AnimateLine(LineRenderer lr,int i)
    {
        float startTime = Time.time;

        Vector3 startPosition = linePoints[i];
        Vector3 endPosition = linePoints[i+1];

        Vector3 pos = startPosition;
        while (pos != endPosition)
        {
            float t = (Time.time - startTime) / animationDuration;
            pos = Vector3.Lerp(startPosition, endPosition, t);
            lr.SetPosition(1, pos);
            yield return null;
        }
        GeneratePoints.Good = true;
    }
}

