﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deck : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
