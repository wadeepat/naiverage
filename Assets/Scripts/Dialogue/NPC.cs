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
    [SerializeField] private TextAsset inkJSON;
    private NavMeshAgent agent;
    private Animator animator;
    private GameObject interactObject;
    private bool playerInRange;
    private TextMeshProUGUI text;
    private GameObject lightObject;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        animator = GetComponent<Animator>();
        interactObject = CanvasManager.instance.GetCanvasObject("InteractText");
        lightObject = transform.Find("Light").gameObject;
        text = interactObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
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
        if (collider.gameObject.tag == "Player")
        {
            if (lightObject != null && lightObject.activeSelf) lightObject.SetActive(false);
            text.text = "Press F to talk ";
            interactObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && InputManager.instance.GetInteractPressed() && !DialogueManager.dialogueIsPlaying)
        {
            if (QuestLog.IsThereSomeQuestTalk(idx) != -1)
                QuestLog.DoQuest(Quest.Objective.Type.talk, (int)NPCIndex.Sata);
            else
                DialogueManager.instance.EnterDialogueMode(inkJSON);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            interactObject.SetActive(false);
        }
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
