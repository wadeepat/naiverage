using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicPearls : MonoBehaviour
{
    public Pearl MP = new Pearl();
    public Image slot;
    public Sprite slotSprite;
    public Text textNum;
    public int maxStacks;
    public int slotStack;

    // Start is called before the first frame update
    void Start()
    {
        MP = Database.magicPearl;
        MP.stack = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        textNum.text = ""+ MP.stack;
    }
}
