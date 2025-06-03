using UnityEngine;
using UnityEngine.UI;

public class BuildingBuyUI : MonoBehaviour
{
    private PurchaseBuilding purchaseBuilding;
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        purchaseBuilding = GetComponent<PurchaseBuilding>();
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = ResourceManager.Instance.CanPay(purchaseBuilding.buildingPrefab.cost);
    }
}
