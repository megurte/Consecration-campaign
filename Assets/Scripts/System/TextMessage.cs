using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMessage : MonoBehaviour
{


    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    [SerializeField]
    float t;
    public Text text;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        //if(t >= 0 && t != 1)
        //    FadeIn();
        //if(t == 1) 
        FadeIn();
    }

    public void FadeIn()
    {
        t = (Time.time - startTime) / duration;
        text.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }

    public void FadeOut()
    {
        t = (Time.time - startTime) / 3;
        text.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
        //if (t == 0)
        //{
        //    gameObject.SetActive(false);
        //}
    }
}

