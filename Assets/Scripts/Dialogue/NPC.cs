using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class NPC : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private NPCIndex idx;
    public TextAsset inkJSON;
    public TextAsset quest;
    private NavMeshAgent agent;
    private Animator animator;
    private GameObject interactObject;
    private bool playerInRange;
    private TextMeshProUGUI text;
    private GameObject lightObject;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        animator = GetComponent<Animator>();
        interactObject = GameObject.Find("Canvas").transform.Find("InteractText").gameObject;
        lightObject = transform.Find("Light").gameObject;
        text = interactObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        // Debug.Log(transform.name);
        if (agent.enabled && !agent.isStopped)
        {
            float distance = Vector2.Distance(transform.position, agent.destination);
            if (distance < agent.stoppingDistance)
            {
                agent.isStopped = true;
                animator.SetBool("isWalking", false);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (this.enabled && collider.gameObject.tag == "Player")
        {
            if (inkJSON == null && quest == null && QuestLog.IsThereSomeQuestTalk(idx) == -1) return;
            if (lightObject != null && lightObject.activeSelf) lightObject.SetActive(false);
            text.text = "Press F to talk ";
            interactObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.enabled && other.gameObject.tag == "Player" && InputManager.instance.GetInteractPressed() && !DialogueManager.dialogueIsPlaying)
        {
            if (inkJSON == null && quest == null && QuestLog.IsThereSomeQuestTalk(idx) == -1) return;

            if (QuestLog.IsThereSomeQuestTalk(idx) != -1)
            {
                QuestLog.DoQuest(Quest.Objective.Type.talk, (int)idx);
            }
            else if (quest != null)
            {
                DialogueManager.instance.EnterDialogueMode(quest);
                quest = null;
            }
            else
                DialogueManager.instance.EnterDialogueMode(inkJSON);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        interactObject.SetActive(false);

        // if (this.enabled && quest == null && collider.gameObject.tag == "Player")
        // {
        //     if (inkJSON == null && QuestLog.IsThereSomeQuestTalk(idx) == -1) return;

        //     interactObject.SetActive(false);
        // }
    }
    public void Goto(Transform place)
    {
        interactObject.SetActive(false);
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetBool("isWalking", true);
        agent.SetDestination(place.position);
        agent.isStopped = false;
    }
}
