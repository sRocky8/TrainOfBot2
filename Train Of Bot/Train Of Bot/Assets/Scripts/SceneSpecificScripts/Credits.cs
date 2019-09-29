using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    //Public Variables
    public float timeToChangeText;
    public Text creditsText;

    //Private Variables
    private float creditsTextValue;

	// Use this for initialization
	void Start () {
        creditsTextValue = 0;
        StartCoroutine(CreditsSwitchCoRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		if(creditsTextValue == 0)
        {
            creditsText.text = "CREDITS\n\nJon Medlin\n_______________________\nMusic\nSound Effects\nTexturer\nProducer";
        }
        if (creditsTextValue == 1)
        {
            creditsText.text = "CREDITS\n\nJosh Rife\n_______________________\nCharacter Modeler\nEnvironment Modeler\nUI Artist\nIllustrator";
        }
        if (creditsTextValue == 2)
        {
            creditsText.text = "CREDITS\n\nRyley Forwood\n_______________________\nCharacter Rigging\nAnimator";
        }
        if (creditsTextValue == 3)
        {
            creditsText.text = "CREDITS\n\nMatt Gendason\n_______________________\nEnvironmental Modeler\nTexturer";
        }
        if (creditsTextValue == 4)
        {
            creditsText.text = "CREDITS\n\nSpencer Roccapriore\n_______________________\nProgrammer";
        }
        if (creditsTextValue == 5)
        {
            creditsText.text = "The End";
        }
        if (creditsTextValue == 6)
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator CreditsSwitchCoRoutine()
    {
        yield return new WaitForSeconds(timeToChangeText);
        creditsTextValue++;
        StartCoroutine(CreditsSwitchCoRoutine());
    }
}
