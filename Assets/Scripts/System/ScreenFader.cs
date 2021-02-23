using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    Animator anim;
    bool isFading = false;


    private void Update()
    {
        
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FadeToClear()
    {
        gameObject.SetActive(false);
        isFading = true;
        anim.SetTrigger("FadeIn");


        while (isFading)
            yield return null;
            
    }

    public IEnumerator FadeToBlack()
    {

        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
            yield return null;
    }

    void AnimationComplite()
    {
        isFading = false;
    }

   
}
