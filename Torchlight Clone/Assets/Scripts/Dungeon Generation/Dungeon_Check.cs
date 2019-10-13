﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Check : MonoBehaviour
{
    //This entire Script might need to be changed later, to take out the test code
    #region Variables
    //variable to decide what to do, open or close the dungeon
    private bool dungeonOpen = false;
    //Object that holds the dungeon Screen
    [SerializeField] private GameObject dungeonScreen;
    //Variable that holds the player Input component
    private Player_Input playerInput;
    #endregion

    #region Set up
    private void Awake()
    {
        //Find the PlayerInput component
        playerInput = GameObject.Find("Main Camera").GetComponent<Player_Input>();

        //Subscription here
        playerInput.OnGPress += DungeonCheck;
    }

    private void Start()
    {
        dungeonOpen = playerInput.inventoryOpen;
        //Disables the inventoryScreen if dungeonOpen is false
        if (dungeonOpen == false)
        {
           dungeonScreen.SetActive(false);
        }
        //Else it makes sure that it's open
        else
        {
            dungeonScreen.SetActive(true);
        }
    }
    #endregion

    #region Inventory Check
    //Open or Close Dungeon
    public void DungeonCheck()
    {
        //Opens the Dungeon Screen
        if (dungeonOpen == false)
        {
            dungeonScreen.SetActive(true);
            dungeonOpen = true;
        }

        //Closes the Dungeon Screen
        else
        {
            dungeonScreen.SetActive(false);
            dungeonOpen = false;
        }
    }
    #endregion
}