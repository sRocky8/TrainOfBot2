using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboRobot : CharacterDialogue {

    public GameObject plunger;
    public GameObject plungerThrown;
    public GameObject hoboSight;
    public Animator animator;
    public bool? hoboThrew;
    public bool playerSqueaking;

    private void Awake()
    {
        if (DataStorage.dataStorage.hoboThrew == null)
        {
            hoboThrew = false;
        }
        else
        {
            hoboThrew = DataStorage.dataStorage.hoboThrew;
        }
    }

    void Start()
    {
        if (hoboThrew == true)
        {
            Debug.Log(hoboThrew);
            plunger.SetActive(false);
            plungerThrown.SetActive(true);
        }
    }

    void Update()
    {
        playerSqueaking = FindObjectOfType<PlayerController>().squeakyWheel;
        if (playerSqueaking == false)
        {
            hoboSight.SetActive(false);
        }
        if(plungerThrown == null)
        {
            return;
        }
        if(hoboThrew == true)
        {
            plungerThrown.SetActive(true);
            plunger.SetActive(false);
        }
        if (find.GetComponent<FindPlayer>().seesPlayer == true)
        {
            if(hoboThrew == false && playerSqueaking == true)
            {
                StartCoroutine(ThrowPlungerCoRoutine());
            }
            CheckDialogueParam();
            TalkWithNPC();
        }
    }

    void CheckDialogueParam()
    {
        if ((playerMenuNum == 0 || playerMenuNum == 1 || playerMenuNum == 2) && playerSqueaking == true)
        {
            dialogueParameter = 0;
        }
        else if ((playerMenuNum == 0 || playerMenuNum == 1 || playerMenuNum == 2) && playerSqueaking == false)
        {
            dialogueParameter = 1;
        }
    }

    private IEnumerator ThrowPlungerCoRoutine()
    {
        animator.Play("Throw part 1");
        yield return new WaitForSeconds(2/3);
        hoboThrew = true;
        animator.Play("Throw part 2");

    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.hoboThrew = hoboThrew;
    }
}
