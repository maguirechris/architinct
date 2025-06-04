using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlaceBuilding : MonoBehaviour
{
    public Tilemap hexTilemap;              // Reference to the hex tilemap
    public GameObject buildingPrefab;       // Reference to the building prefab
    private Cost cost;
    public bool isPlacing = false;
    public static PlaceBuilding Instance;
    public Image buildMode;

    void Update()
    {
        if (isPlacing)
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
                        newBuilding.transform.SetParent(transform);
                        newBuilding.SetActive(true);
                        PlacedBuildingManager manager = buildingPrefab.transform.parent.gameObject.GetComponent<PlacedBuildingManager>();
                        manager.placedBuildings.Add(newBuilding.GetComponent<Building>());
                        ResourceManager.Instance.Pay(cost);
                        if (!ResourceManager.Instance.CanPay(cost))
                            EndBuildMode();
                        
                    }
                    else
                    {
                        Debug.Log("A building already exists on this tile.");
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EndBuildMode();
            }
        }
    }

    public void SetPlacementMode(bool enabled)
    {
        isPlacing = enabled;
    }

    public void StartBuildMode(Building building)
    {
        buildingPrefab = building.gameObject;
        cost = building.GetComponent<Cost>();
        ButtonManager.Instance.HideButtons();
        buildMode.gameObject.SetActive(true);
    }

    public void EndBuildMode()
    {
        isPlacing = false;
        ButtonManager.Instance.ShowButtons();
        buildMode.gameObject.SetActive(false);
    }
    

    public void TogglePlacement()
    {
        isPlacing = !isPlacing;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
