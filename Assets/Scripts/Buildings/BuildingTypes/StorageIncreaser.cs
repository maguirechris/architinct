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
            ResourceManager.Instance.ChangeLimit(value, ResourceManager.Instance.GetColorFromEnum((int)colors[i]));
        }

    }
}
