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
        for(int i = 0; i < colors.Length; i++) {
            ResourceManager.Instance.ChangeGainRate(value, ResourceManager.Instance.GetColorFromEnum((int) colors[i]));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
