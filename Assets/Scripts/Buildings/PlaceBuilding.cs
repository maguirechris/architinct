using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceBuilding : MonoBehaviour
{
    public Tilemap hexTilemap;              // Reference to the hex tilemap
    public GameObject buildingPrefab;       // Reference to the building prefab
    public bool isPlacing = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = hexTilemap.WorldToCell(mouseWorldPos);

            // Check if there's a tile at that position before placing
            if (hexTilemap.HasTile(cellPosition))
            {
                Vector3 tileCenter = hexTilemap.GetCellCenterWorld(cellPosition);

                // Optional: check if a building is already there
                Collider2D[] existing = Physics2D.OverlapCircleAll(tileCenter, 0.1f);
                if (existing.Length == 0)
                {
                    GameObject newBuilding = Instantiate(buildingPrefab, tileCenter, Quaternion.identity);
                    newBuilding.transform.parent = transform;
                    newBuilding.SetActive(true);
                }
                else
                {
                    Debug.Log("A building already exists on this tile.");
                }
            }
        }
    }

    public void SetPlacementMode(bool enabled)
    {
        isPlacing = enabled;
    }
    

    public void TogglePlacement()
    {
        isPlacing = !isPlacing;
    }
}
