using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
            description ="“เจ้าได้ค้นพบปริศนาอันใหม่แล้ว”\n“ชักจะไม่ง่ายแล้วสิ”\n“เจ้าจะได้เจอเรื่องราวต่าง ๆ อีกมากมาย”"
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
    public void ActivateMenu(int idx)
    {
        cardIdx = idx;
        header.text = cardDetails[idx].header;
        desc.text = cardDetails[idx].description;
        timer = 0;
        this.gameObject.SetActive(true);
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
        // if (cardIdx != 0)
        ActionHandler.instance.AskToSave();
    }
}
