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
        if(!PlaceBuilding.Instance.isPlacing)
            ResourceManager.Instance.ChangeValue(value * multiplier, ResourceManager.Instance.GetColorFromEnum((int)color));
    }

}
