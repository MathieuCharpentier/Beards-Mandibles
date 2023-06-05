using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Inventory inventory;
    public string charName;
    GameObject charToGive;
    bool isDragging;
    Vector2 InitPos;
    public static int slot;

    void Start()
    {
        InitPos = transform.localPosition;
        charToGive = GameObject.Find(charName);
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if(isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        else
        {
            float distanceX = charToGive.transform.position.x - transform.position.x;
            float distanceY = charToGive.transform.position.y - transform.position.y;
            if (distanceX > -1.5f && distanceX < 1.5f && distanceY > -2f && distanceY < 2f)
            {
                inventory.isFull[slot] = false;
                charToGive.SendMessage("PlayerGive");
                Destroy(gameObject);
            }
            else           
            transform.localPosition = InitPos;
            
        }
    }

    void OnMouseDown()
    {
       isDragging = true; 
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    public void WhatSlot(int Slot)
    {
        slot = Slot;
    }
}
