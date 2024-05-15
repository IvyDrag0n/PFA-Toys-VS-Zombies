using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class GridTest : MonoBehaviour
{
    private GridMap grid;
    // Start is called before the first frame update
    void Start()
    {
         grid = new GridMap(4,2, 1f, new Vector3(-2, 0));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValueFromPosition(UtilsClass.GetMouseWorldPosition(), 56);
        }
    }
}
