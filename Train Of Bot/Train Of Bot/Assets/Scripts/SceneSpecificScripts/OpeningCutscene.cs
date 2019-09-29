using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour {

    //Public Variables
    public Animator cutScene;
    public Animator fade;
    public float timeToWait;
    public GameObject fadeGameObject;

    //Private Variables

    
	void Start () {
        StartCoroutine(CutsceneCoRoutine());
	}
	
	void Update () {
		
	}

    private IEnumerator CutsceneCoRoutine()
    {
        fade.Play("FadeIn");

        yield return new WaitForSeconds(2);
        fadeGameObject.SetActive(false);

        cutScene.Play("OpeningCutscene");

        yield return new WaitForSeconds(14);

        StartCoroutine(FadeOutCoRoutine());
    }

    private IEnumerator FadeOutCoRoutine()
    {
        fadeGameObject.SetActive(true);

        fade.Play("FadeOut");

        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(2);
    }
}
