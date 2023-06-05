using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemPrefab;
    Animator dialogueCanvas;
    TextMeshProUGUI dialogueText;
    GameObject objectGived;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        dialogueCanvas = GameObject.Find("DialogCanvas").GetComponentInChildren<Animator>();
        dialogueText = GameObject.Find("DialogText").GetComponentInChildren<TextMeshProUGUI>();
    }

 
    void OnMouseDown()
    {
        if(inventory.isFull[3] == true)
        {
            dialogueText.SetText("Vous ne pouvez plus rien porter");
            dialogueCanvas.SendMessage("Fade");
        }
        else
        for(int i=0; i<inventory.slots.Length; i++)
        {    
            if(inventory.isFull[i] == false)
            {
                objectGived = Instantiate(itemPrefab, inventory.slots[i].transform, false);
                Destroy(gameObject);
                objectGived.SendMessage("WhatSlot", i);
                inventory.isFull[i] = true;
                break;
            }
        } 
    }
}
