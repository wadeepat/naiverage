using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicPearls : MonoBehaviour
{
    public static Pearl MP = new Pearl();
    [SerializeField] private Image slot;
    [SerializeField] private Sprite slotSprite;
    [SerializeField] private Text textNum;
    private int maxStacks;
    private int slotStack;

    // Start is called before the first frame update
    void Start()
    {
        MP = Database.magicPearl;
        MP.stack = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        textNum.text = ""+ MP.stack;
    }

    public static int CheckPearl(){
        return MP.stack;
    }

    public static void UsePearl(int cost){
        MP.stack -= cost;
    }

    public static void GetPearl(int cost){
        MP.stack += cost;
    }

}
