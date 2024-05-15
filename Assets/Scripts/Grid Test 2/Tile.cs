using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material material, offsetMaterial;

    [SerializeField] private Material highlightMaterial;

    [SerializeField] private MeshRenderer tileRenderer;

    private Material _baseMaterial;

    public bool isHighlighted;

    public int currentTower;

    public bool isShielded;

    [Range(0, 4)] private int infectionStage;

    [Range(0, 10)] private int health;

    public List<GameObject> turretPlanesList;

    public GameObject shieldPlane;

    public void Init(bool isOffset)
    {
        _baseMaterial = isOffset ? offsetMaterial : material;
        tileRenderer.material = _baseMaterial;
    }

    public void HighlightTile()
    {
        isHighlighted = true;

        tileRenderer.material = highlightMaterial;
    }

    public void UnHighlightTile()
    {
        isHighlighted = false;

        tileRenderer.material = _baseMaterial;
    }
    
}
