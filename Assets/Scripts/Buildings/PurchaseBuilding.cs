using UnityEngine;

public class PurchaseBuilding : MonoBehaviour
{
    public GameObject buildingPrefab;
    public GameObject buildingMenu;
    public Cost cost;

    public void Purchase()
    {
        Cost cost = buildingPrefab.GetComponent<Cost>();
        if (cost == null)
        {
            Debug.LogError("Building prefab does not have a price.");
            return;
        }

        if (ResourceManager.Instance.CanPay(cost))
        {
            ResourceManager.Instance.Pay(cost);

            PlaceBuilding placer = Object.FindFirstObjectByType<PlaceBuilding>();
            if (placer != null)
            {
                placer.buildingPrefab = buildingPrefab;
                placer.SetPlacementMode(true);
            }

            if (buildingMenu != null)
            {
                buildingMenu.SetActive(false);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
