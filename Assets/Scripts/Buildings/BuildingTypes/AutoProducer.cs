using UnityEngine;

public class AutoProducer : Building
{
    public enum Color
    {
        Red, Blue, Green
    }

    public Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Color color in colors) {
            ResourceManager.Instance.ChangeGainRate(value * multiplier, ResourceManager.Instance.GetColorFromEnum((int) color));
        }
        
    }

    // Update is called once per frame
    public override void OnUpgrade(float oldValue)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            ResourceManager.Instance.ChangeGainRate((value * multiplier) - oldValue, ResourceManager.Instance.GetColorFromEnum((int)colors[i]));
        }
    }


}
