using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : CharacterDialogue {

    public bool? frozen;
    public float thrust;
    public Vector3 puzzleBegin;
    public Vector3 puzzleEnd;
    public GameObject spoon;
    public GameObject moveForward;
    public GameObject moveLeft;
    public GameObject moveRight;
    public GameObject moveBack;
    public Animator animator;
    public Animator iceAnimator;

    private Rigidbody rb;

    private void Awake()
    {
        if (DataStorage.dataStorage.chefCanGive == null)
        {
            canGiveItem = true;
        }
        else
        {
            canGiveItem = DataStorage.dataStorage.chefCanGive;
        }

        if (DataStorage.dataStorage.chefFrozen == null)
        {
            frozen = true;
        }
        else
        {
            frozen = DataStorage.dataStorage.chefFrozen;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        transform.position = puzzleBegin;
        if (frozen == false)
        {
            animator.Play("Shivering");
            iceAnimator.Play("IceGone");
        }
    }

    void Update()
    {
        if (frozen == true)
        {
            rb.isKinematic = false;

            if (moveForward.GetComponent<FindPlayer>().seesPlayer == true && (Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.UpArrow) == true))
            {
                rb.AddForce(-transform.forward * thrust);
            }
            else if (moveLeft.GetComponent<FindPlayer>().seesPlayer == true && (Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true))
            {
                rb.AddForce(transform.right * thrust);
            }
            else if (moveRight.GetComponent<FindPlayer>().seesPlayer == true && (Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.RightArrow) == true))
            {
                rb.AddForce(-transform.right * thrust);
            }
            else if (moveBack.GetComponent<FindPlayer>().seesPlayer == true && (Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.DownArrow) == true))
            {
                rb.AddForce(transform.forward * thrust);
            }

        }
        if (frozen == false)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Frozen") == true)
            {
                animator.SetTrigger("Frozen to thawing");
                iceAnimator.Play("IceMelt");
            }
            moveBack.SetActive(false);
            moveForward.SetActive(false);
            moveRight.SetActive(false);
            moveLeft.SetActive(false);
            rb.isKinematic = true;
            transform.position = puzzleEnd;
            if (spoon != null)
            {
                if (canGiveItem == false)
                {
                    spoon.SetActive(true);
                }
            }
            
            if (find.GetComponent<FindPlayer>().seesPlayer == true)
            {
                CheckDialogueParam();
                TalkWithNPC();
            }
        }
    }

    void CheckDialogueParam()
    {
        if ((playerMenuNum == 0 || playerMenuNum == 1 || playerMenuNum == 2) && canGiveItem == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                canGiveItem = false;
            }
            else
            {
                dialogueParameter = 0;
            }
        }
        else if ((playerMenuNum == 0 || playerMenuNum == 1 || playerMenuNum == 2) && canGiveItem == false)
        {
            dialogueParameter = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oven")
        {
            frozen = false;
            Debug.Log(frozen);
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.chefCanRecieve = canRecieveItem;
        DataStorage.dataStorage.chefCanGive = canGiveItem;
        DataStorage.dataStorage.chefFrozen = frozen;
    }
}
