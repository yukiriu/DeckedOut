﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate;

    void Start()
    {
        Populate();
    }

    void Update()
    {
        
    }

    void Populate()
    {
        GameObject newObj;

        for (int i = 0; i < numberToCreate; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV();
        }
    }
}
