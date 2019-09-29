using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour {

    //Public Variables
    public Animator fade;
    public float timeToWait;
    public GameObject fadeGameObject;
    public float waitToFade;

    //Private Variables


    void Start()
    {
        StartCoroutine(CutsceneCoRoutine());
    }

    void Update()
    {

    }

    private IEnumerator CutsceneCoRoutine()
    {
        fade.Play("FadeIn");

        yield return new WaitForSeconds(2);
        fadeGameObject.SetActive(false);

        yield return new WaitForSeconds(waitToFade);

        StartCoroutine(FadeOutCoRoutine());
    }

    private IEnumerator FadeOutCoRoutine()
    {
        fadeGameObject.SetActive(true);

        fade.Play("FadeOut");

        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(8);
    }
}
