using UnityEngine;

public class Research : MonoBehaviour
{
    public bool lockedOnStart = true;
    [HideInInspector] public bool locked;
    [HideInInspector] public bool researched;
    [HideInInspector] public int numPrereqs;
    public Cost cost;
    public Research[] unlocks;
    public Building[] buildings;
    public ResearchSO researchSO;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        locked = lockedOnStart;
        foreach(Research research in unlocks)
        {
            research.numPrereqs++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable()
    {
        bool paid = ResourceManager.Instance.CanPay(cost);

        if (paid)
        {

            ResourceManager.Instance.Pay(cost);
            researched = true;
            foreach (Research research in unlocks)
            {
                research.Unlock();
            }

            foreach (Building building in buildings)
                if (building)
                {
                    building.ApplyResearch(researchSO);
                    foreach (Building placedBuilding in building.transform.parent.GetComponent<PlacedBuildingManager>().placedBuildings)
                    {
                        float oldval = placedBuilding.ApplyResearch(researchSO);
                        placedBuilding.OnUpgrade(oldval);
                    }
                }
            

        }

    }

    public void Unlock()
    {
        numPrereqs--;
        if(numPrereqs <= 0)
            locked = false;
    }
}
