using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform cam;

    [SerializeField] private Transform camAim;

    private Tile[,] _gridArray;

    public Tile highlightedTile;

    public Vector3 highlightXY;

    public GameObject currentMenu;

    [SerializeField] private GameObject turretMenu;

    private TurretMenu _turretMenuScript;
    
    [SerializeField] private GameObject editMenu;

    private EditMenu _editMenuScript;

    public GameObject resourceDisplay;

    private RessourceDisplay _resourceDisplayScript;

    public int money;

    public int infectMoney;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        _turretMenuScript = turretMenu.GetComponent<TurretMenu>();
        _editMenuScript = editMenu.GetComponent<EditMenu>();
        _resourceDisplayScript = resourceDisplay.GetComponent<RessourceDisplay>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        _gridArray = new Tile[width,height];
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //Spawn and rename the tile at appropriate location
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x*2, 0, y*2), Quaternion.identity, transform); 
                spawnedTile.name = $"Tile {x} {y}";

                // Add it to the array
                _gridArray[x, y] = spawnedTile;

                //Set its material
                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset); 

            }
        }

        cam.position =
            new Vector3((float)width - 1f, cam.transform.position.y, cam.position.z);

        camAim.position = new Vector3((float)width - 1f, 0, (float)height - 1f);
        
        highlightedTile = _gridArray[0, 0];
        highlightedTile.HighlightTile();
        highlightXY = new Vector3(0, 0);
    }

    private void UpdateHighlight()
    {
        highlightedTile.UnHighlightTile();
        highlightedTile = _gridArray[(int)highlightXY.x, (int)highlightXY.y];
        highlightedTile.HighlightTile();
    }
    
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (context.started && currentMenu == null)
        {
            if ((int)highlightXY.y == height - 1)
            {
                highlightXY.y = 0;
            }
            else
            {
                highlightXY.y += 1;
            }
            
            UpdateHighlight();
        }
    }
    
    public void MoveDown(InputAction.CallbackContext context)
    {
        if (context.started && currentMenu == null)
        {
            if ((int)highlightXY.y == 0)
            {
                highlightXY.y = height - 1;
            }
            else
            {
                highlightXY.y -= 1;
            }
            
            UpdateHighlight();
        }
    }
    
    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started && currentMenu == null)
        {
            if ((int)highlightXY.x == width - 1)
            {
                highlightXY.x = 0;
            }
            else
            {
                highlightXY.x += 1;
            }
            
            UpdateHighlight();
        }
    }
    
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started && currentMenu == null)
        {
            if ((int)highlightXY.x == 0)
            {
                highlightXY.x = width - 1;
            }
            else
            {
                highlightXY.x -= 1;
            }
            
            UpdateHighlight();
        }
    }

    public void Select(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (currentMenu == null)
            {
                if (highlightedTile.currentTower == 0)
                {
                    turretMenu.SetActive(true);
                    currentMenu = turretMenu;
                    
                }
                else
                {
                    editMenu.SetActive(true);
                    currentMenu = editMenu;
                }
                resourceDisplay.SetActive(false);
            }
        }
    }

    public void Back(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (currentMenu != null)
            {
                _turretMenuScript.hasOpened = false;
                if (currentMenu == editMenu)
                {
                    _editMenuScript.defaultButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                    _editMenuScript.hasOpened = false;
                }
                else if (currentMenu == turretMenu)
                {
                    _turretMenuScript.defaultButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                    _turretMenuScript.hasOpened = false;
                }
                currentMenu.SetActive(false);
                currentMenu = null;
                resourceDisplay.SetActive(true);
                
            }
            else
            {
                
            }
        }
    }
}
