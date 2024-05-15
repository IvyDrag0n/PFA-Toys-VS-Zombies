using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditMenu : MonoBehaviour
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
    }

    public void OnButtonClick()
    {
        if (hasOpened)
        {
            GameObject button = EventSystem.current.currentSelectedGameObject;
            
            switch (button.name)
            {
                case "Button1": //Recycle
                    gridManager.highlightedTile.turretPlanesList[gridManager.highlightedTile.currentTower - 1].SetActive(false);
                    gridManager.highlightedTile.shieldPlane.SetActive(false);
                    gridManager.highlightedTile.currentTower = 0;
                    
                    break;
                case "Button2": //Shield
                    gridManager.highlightedTile.shieldPlane.SetActive(true);
                    gridManager.highlightedTile.isShielded = true;
                    break;
            }
            
            hasOpened = false;
            gridManager.currentMenu = null;
            gridManager.resourceDisplay.SetActive(true);
            gameObject.SetActive(false);
        }
        else hasOpened = true;
    }
}