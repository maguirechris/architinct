using TMPro;
using UnityEngine;

public class ResourceText : MonoBehaviour
{
    public enum Color
    {
        Red, Blue, Green
    }
    public string label;
    public Color resourceType = Color.Red;
    private TextMeshProUGUI text;
    private ResourceManager resourceManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        resourceManager = ResourceManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float value = resourceManager.GetValue((int)resourceType);
        float gainRate = resourceManager.GetGainRate((int)resourceType);
        string newText = label;
        if (value == 0)
            newText += ": 0";
        else if (value >= 500000 || value <= -500000)
            newText += ": " + string.Format("{0:0,,.0}M", value);
        else if (value >= 1000 || value <= -1000)
            newText += ": " + string.Format("{0:0,.0}K", value);
        else
            newText += ": " + string.Format("{0:0.0}", value);

        if (gainRate >= 1000000 || gainRate <= -1000000)
            newText += string.Format(" ({0:0,,.#}M/s)", gainRate);
        else if (gainRate >= 1000 || gainRate <= -1000)
            newText += string.Format(" ({0:0,.#}K/s)", gainRate);
        else
            newText += string.Format(" ({0:0.#}/s)", gainRate);
        

        text.text = newText;
    }
}
