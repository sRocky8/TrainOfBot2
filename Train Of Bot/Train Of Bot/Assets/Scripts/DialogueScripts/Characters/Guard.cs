using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : CharacterDialogue {

    public bool playerWin;

    private bool canActivateCoRoutine;

    void Start()
    {
        canActivateCoRoutine = true;
        playerWin = false;
    }

    void Update()
    {
        if (find.GetComponent<FindPlayer>().seesPlayer == true)
        {
            CheckDialogueParam();
            TalkWithNPC();
        }
    }

    void CheckDialogueParam()
    {
        if ((playerMenuNum == 0 || playerMenuNum == 0 || playerMenuNum == 0) && FindObjectOfType<PlayerController>().kissed == false)
        {
            dialogueParameter = 0;
        }
        else if ((playerMenuNum == 0 || playerMenuNum == 0 || playerMenuNum == 0) && FindObjectOfType<PlayerController>().kissed == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                endedDialogue = false;
                if (canActivateCoRoutine == true)
                {
                    StartCoroutine(WaitForDialogueToFinishCoRoutine());
                }
            }
            else
            {
                dialogueParameter = 1;
            }
        }
    }

    private IEnumerator WaitForDialogueToFinishCoRoutine()
    {
        canActivateCoRoutine = false;
        yield return new WaitUntil(() => endedDialogue == true);
        FindObjectOfType<PlayerController>().inConversation = false;
        playerWin = true;
    }
}
