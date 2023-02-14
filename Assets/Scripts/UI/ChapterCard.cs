using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
public class ChapterCard : MonoBehaviour
{
    private class ChapterCardDetails
    {
        public string header;
        public string description;
    };
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI desc;
    private int cardIdx;

    private List<ChapterCardDetails> cardDetails = new List<ChapterCardDetails>(){
        new ChapterCardDetails(){
            header = "บทที่ 0: จุดเริ่มต้นในเมืองเนเวอร์",
            description ="“จงอย่าเชื่อหนังสือเพียงแค่ดูปกหนังสือ”\n“จงเปิดอ่านมันแล้วหาคำตอบ”\n“ภายในหนังสือนั้นจะไม่มีทางที่จะโกหกเจ้า”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 1: สู่การเป็นทหาร",
            description ="“การผจญภัยได้เริ่มขึ้นแล้ว”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 2: เจ้าชายที่หายไป",
            description ="“เจ้าได้ค้นพบรับรู้ปริศนาใหม่แล้ว”\n“เรื่องชักจะไม่ง่ายแล้วสิ”\n“เจ้าจะได้เจอเรื่องราวต่าง ๆ อีกมากมาย”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 3: การพบการของสองพี่น้อง",
            description ="“เรื่องราวของเจ้าชายทั้งสองจะเป็นอย่างไร”\n“ปริศนาของเรื่องราวต่าง ๆ”\n“ เจ้าจะได้เห็นชัดเจนขึ้น”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 4: เส้นทางถูกเลือก",
            description ="“เรื่องวุ่นวายต่าง ๆ เหล่านี้”\n“เจ้าเห็นมันอย่างชัดเจนหรือยัง”\n“เลือกเส้นทางที่ลิขิตด้วยตัวเจ้าเอง”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 1.1: หวนคืนสู่การเป็นทหาร",
            description ="“การผจญภัยได้เริ่มขึ้นอีกครั้ง”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 2.1: ตามหาเจ้าชาย",
            description ="“เจ้าชายผู้น่าสงสหาร”\n“การเปลี่ยนแปลง”\n"
        },
        new ChapterCardDetails(){
            header = "บทที่ 3.1: สองพี่น้อง",
            description ="“เหตุผลของการกลับมา”\n“สิ่งที่ซ่อนอยู่”"
        },
        new ChapterCardDetails(){
            header = "บทที่ 4.1: เส้นทางที่แท้จริง",
            description ="“การเปลี่ยนแปลง”\n“ความลับของบัญญัติ”\n“บทสรุปของเรื่องราวที่แท้จริง”"
        },
    };
    private float timer = 0;
    private float readTime = 1.75f;
    private float displayTime = 3.5f;

    private void Update()
    {
        if (timer >= displayTime) DeactivateMenu();
        else if (timer >= readTime)
        {
            animator.SetTrigger("fadeOut");
            timer += Time.deltaTime;
        }
        else timer += Time.deltaTime;
    }
    private void SetForActivateUI()
    {
        // DialogueManager.dialogueIsPlaying = true;
        // DialogueManager.instance.LockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(true);
        // DialogueManager.instance.EnablePlayerControll();
    }
    private void ResetForDeactivateUI()
    {
        // DialogueManager.dialogueIsPlaying = false;
        // DialogueManager.instance.UnlockCamera();
        PlayerManager.instance?.player.GetComponent<ThirdPersonController>().SetLockCameraPosition(false);
        // DialogueManager.instance.DisablePlayerControll();
    }
    public void ActivateMenu(int idx)
    {
        SetForActivateUI();
        AudioManager.instance.Play("newChapter");
        cardIdx = idx;
        header.text = cardDetails[idx].header;
        desc.text = cardDetails[idx].description;
        timer = 0;
        this.gameObject.SetActive(true);
        // Debug.Log("ActiveCard " + DialogueManager.dialogueIsPlaying);
    }
    public void DeactivateMenu()
    {
        ResetForDeactivateUI();
        this.gameObject.SetActive(false);
        if (cardIdx != 0)
            ActionHandler.instance.AskToSave();
        // Debug.Log("DeactiveCard " + DialogueManager.dialogueIsPlaying);
    }
    public bool IsActivated()
    {
        return this.gameObject.activeSelf;
    }
}
