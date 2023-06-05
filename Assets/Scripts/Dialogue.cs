using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    Animator dialogueAnimator;
    bool isFading;
    public float timer;
    
    void Start()
    {
        dialogueAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(isFading)
        {
            timer += Time.deltaTime;
            if(timer >= 10)
            {
                dialogueAnimator.Play("DialogueFadeOut");
                timer = 0f;
                isFading = false;
            }
        }
    }

    public void StopText()
    {
        if (isFading)
        timer = 9.8f;
    }

    public void Fade()
    {
        dialogueAnimator.Play("DialogueFadeIn");
        isFading = true;
    }
}
