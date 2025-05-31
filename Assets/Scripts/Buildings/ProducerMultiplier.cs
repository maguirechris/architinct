using UnityEngine;

public class ProducerMultiplier : MonoBehaviour
{
    public enum Color
    {
        Red, Blue, Green
    }

    public float multiplier;
    public Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            ResourceManager.Instance.ChangeMultiplier(multiplier, ResourceManager.Instance.GetColorFromEnum((int)colors[i]));
        }

    }
}
