using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttonArray;

    public Button defaultButton;

    public bool hasOpened;

    [SerializeField] private GridManager gridManager; 
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (defaultButton == null)
        {
            defaultButton = buttonArray[0];
        }
        defaultButton.Select();
        Debug.Log("aaaaa");
    }

    public void OnButtonClick()
    {
        if (hasOpened)
        {
            GameObject button = EventSystem.current.currentSelectedGameObject;
            int i = 0;
            switch (button.name)
            {
                case "Button1":
                    i = 1;
                    break;
                case "Button2":
                    i = 2;
                    break;
                case "Button3":
                    i = 3;
                    break;
                case "Button4":
                    i = 4;
                    break;
                case "Button5":
                    i = 5;
                    break;
                case "Button6":
                    i = 6;
                    break;
                case "Button7":
                    i = 7;
                    break;
                case "Button8":
                    i = 8;
                    break;



            }

            gridManager.highlightedTile.currentTower = i;
            gridManager.highlightedTile.turretPlanesList[i - 1].SetActive(true);
            hasOpened = false;
            gridManager.currentMenu = null;
            gridManager.resourceDisplay.SetActive(true);
            gameObject.SetActive(false);
        }
        else hasOpened = true;
    }
}
