using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private static Fader instance;
    private static bool shouldAnimatePlay = false;
    private Animator animator;
    private AsyncOperation loadingScene;


    void Start()
    {
        animator = GetComponent<Animator>();
        instance = this;
        if (shouldAnimatePlay) animator.SetTrigger("FadeOut");
    }

    public static void ChangeScene(int index)
    {
        instance.animator.SetTrigger("FadeIn");
        instance.loadingScene = SceneManager.LoadSceneAsync(index);
        instance.loadingScene.allowSceneActivation = false;
    }

    public static void ChangeSlide()
    {
        instance.animator.SetTrigger("FadeIn");
    }

    public void OnAnimationEnd()
    {
        loadingScene.allowSceneActivation = true;
        shouldAnimatePlay = true;
    }
}
