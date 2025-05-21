using UnityEngine;

public class Research : MonoBehaviour
{
    public bool lockedOnStart = true;
    [HideInInspector] public bool locked;
    [HideInInspector] public bool researched;
    public Cost cost;
    public Research[] unlocks;
    public Building building;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        locked = lockedOnStart;
        if (building)
            building.researched = !locked;
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

            if (building)
                building.researched = true;

        }

    }

    public void Unlock()
    {
        locked = false;
    }
}
