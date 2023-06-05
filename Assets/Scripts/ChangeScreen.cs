using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ChangeScreen : MonoBehaviour
{
    public UnityEvent buttonPressed;
    public float newPos;
    public bool Vertical;
    public bool Horizontal;
    Camera cam;
    SpriteRenderer render;
    bool hover;
    public Animator FadeAnim;

    void Start()
    {
        cam = Camera.main;
        render = GetComponentInChildren<SpriteRenderer>();
        FadeAnim = GameObject.Find("FadeCanvas").GetComponentInChildren<Animator>();
        render.color = new Color (255, 255, 255, 0.5f);
    }

    void OnMouseDown()
    {
        StartCoroutine("MoveCamera");
        buttonPressed.Invoke();
    }

    void OnMouseOver()
    {
        render.color = new Color (255, 255, 255, 1);
    }

    void OnMouseExit()
    {
        render.color = new Color (255, 255, 255, 0.5f);
    }

    IEnumerator MoveCamera()
    {
        FadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(0.5f);
        if(Vertical)
        cam.transform.DOMoveY(newPos,0f);
        if(Horizontal)
        cam.transform.DOMoveX(newPos,0f);
        FadeAnim.Play("FadeOut");
    }
}
