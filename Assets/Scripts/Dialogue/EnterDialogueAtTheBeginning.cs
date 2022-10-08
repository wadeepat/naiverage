using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialogueAtTheBeginning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset inkJSON;
    // private float time = 1.5f;
    void Start()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        AudioManager.GetInstance().Play("forestBackground");
        // StartCoroutine(Prepare());
    }

    // private IEnumerator Prepare()
    // {
    //     yield return new WaitForSeconds(time);
    //     DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    //     AudioManager.GetInstance().Play("forestBackground");
    // }
}
