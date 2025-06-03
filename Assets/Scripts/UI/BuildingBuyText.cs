using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingBuyText : MonoBehaviour
{
    public enum Color
    {
        Red, Blue, Green
    }
    public string label;
    public Color resourceType = Color.Red;
    private TextMeshProUGUI text;
    public PurchaseBuilding buildingBuyObj;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {

        float value = buildingBuyObj.buildingPrefab.cost.GetValue((int)resourceType);

        string newText = label;
        if (value == 0)
            newText += ": 0";
        else if (value >= 500000 || value <= -500000)
            newText += ": " + string.Format("{0:0,,.0}M", value);
        else if (value >= 1000 || value <= -1000)
            newText += ": " + string.Format("{0:0,.0}K", value);
        else
            newText += ": " + string.Format("{0:0.0}", value);
        

        text.text = newText;
    }
}
