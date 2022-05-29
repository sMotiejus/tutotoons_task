using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSize : MonoBehaviour
{
    private float h = 1920f, w = 1080f;
    private GameObject canvas;
    private RectTransform canvasTransform;
    private RectTransform mainObject;
    void Start()
    {
        canvas = transform.parent.gameObject;
        canvasTransform = canvas.GetComponent(typeof(RectTransform)) as RectTransform;
        mainObject = GetComponent(typeof(RectTransform)) as RectTransform;
    }

    private void Update()
    {
        float wn = canvasTransform.rect.width;
        float hn = canvasTransform.rect.height;
        if(wn != w || hn != h)
        {
            SetSize(wn, hn);
            w = wn;
            h = hn;
        }
    }

    void SetSize(float cwidth, float cheight)
    {
        mainObject.sizeDelta = new Vector2(cwidth, cheight);
    }





}
