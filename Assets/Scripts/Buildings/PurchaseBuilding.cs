using Unity.VisualScripting;
using UnityEngine;

public class PurchaseBuilding : MonoBehaviour
{
    public Building buildingPrefab;
    private GameObject buildingMenu;
    public AudioSource audioSource;
    public AudioClip purchaseClip;

    public void Purchase()
    {
        Cost cost = buildingPrefab.cost;
        if (cost == null)
        {
            Debug.LogError("Building prefab does not have a price.");
            return;
        }

        if (ResourceManager.Instance.CanPay(cost))
        {

            PlaceBuilding placer = PlaceBuilding.Instance;
            if (placer != null)
            {
                placer.StartBuildMode(buildingPrefab);

                placer.SetPlacementMode(true);
                PlaySound(purchaseClip);
            }

            if (buildingMenu != null)
            {
                MenuManager.ClosePrimaryMenu();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingMenu = BuildingMenu.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void PlaySound(AudioClip clip) {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
