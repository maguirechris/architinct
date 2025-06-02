using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StorageIncreaser : Building
{
    public enum Color
    {
        Red, Blue, Green
    }

    public Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            ResourceManager.Instance.ChangeLimit(value * multiplier, ResourceManager.Instance.GetColorFromEnum((int)colors[i]));
        }

    }

    public override void OnUpgrade(float oldValue)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            ResourceManager.Instance.ChangeLimit((value * multiplier) - oldValue, ResourceManager.Instance.GetColorFromEnum((int)colors[i]));
        }
    }
}
