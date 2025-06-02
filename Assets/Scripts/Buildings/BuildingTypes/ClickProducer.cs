using UnityEngine;

public class ClickProducer : Building
{
    public enum Color
    {
        Red, Blue, Green
    }

    public Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        ResourceManager.Instance.ChangeValue(value, ResourceManager.Instance.GetColorFromEnum((int)color));
    }
}
