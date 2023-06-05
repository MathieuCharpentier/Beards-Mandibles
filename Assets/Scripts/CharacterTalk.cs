using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterTalk : MonoBehaviour
{
    [Header("Text")]
    public string characterSpeech;
    public string receiveItem;
    [Header("ItemBool")]
    public bool giveItem;
    public bool giveOnQuestComplete;
    bool given;
    public bool end;

    Animator dialogueCanvas;
    Animator FadeAnim;
    TextMeshProUGUI dialogueText;
    private GiveItem give;


    void Start()
    {
        give = gameObject.GetComponentInChildren<GiveItem>();
        FadeAnim = GameObject.Find("FadeCanvas").GetComponentInChildren<Animator>();
        dialogueCanvas = GameObject.Find("DialogCanvas").GetComponentInChildren<Animator>();
        dialogueText = GameObject.Find("DialogText").GetComponentInChildren<TextMeshProUGUI>();
        if(characterSpeech == "")
        {
            characterSpeech = "Error";
        }

        if(receiveItem == "")
        {
            receiveItem = "Error";
        }
    }

    void OnMouseDown()
    {
        dialogueText.SetText(characterSpeech);
        dialogueCanvas.SendMessage("Fade");
        if(giveItem && !giveOnQuestComplete && !given)
        {
            give.ItemGive();
            given = true;
        }
    }

    public void PlayerGive()
    {
        dialogueText.SetText(receiveItem);
        dialogueCanvas.SendMessage("Fade");

        if(end)
        {
            FadeAnim.Play("EndAnim");
        }

        if(giveItem && giveOnQuestComplete && !given)
        {
            give.ItemGive();
            given = true;
        }
    }
}
