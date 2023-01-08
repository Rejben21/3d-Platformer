using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;

    public Image fadeScreen;
    public float fadeSpeed = 1;
    private bool fadeToBlack, fadeFromBlack;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1)
            {
                fadeToBlack = false;
            }
        }

        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeFromBlack = false;
        fadeToBlack = true;
    }

    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
    }
}
