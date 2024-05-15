using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceDisplay : MonoBehaviour
{
    [SerializeField] private Text moneyDisplay;
    
    [SerializeField] private Text infectDisplay;

    [SerializeField] private GridManager gridManager;

    private void OnEnable()
    {
        UpdateResource();
    }

    public void UpdateResource()
    {
        moneyDisplay.text = gridManager.money.ToString();
        infectDisplay.text = gridManager.infectMoney.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            gridManager.money += 20;
            UpdateResource();
        }

        if (Input.GetKeyDown("i"))
        {
            gridManager.infectMoney += 20;
            UpdateResource();
        }
    }
}
