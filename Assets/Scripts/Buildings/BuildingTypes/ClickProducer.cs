using UnityEngine;

public class ClickProducer : Building
{
    public enum Color
    {
        Red, Blue, Green
    }

    public Color color;
    public AudioSource audioSource;
    public AudioClip collectResource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        if (!PlaceBuilding.Instance.isPlacing)
        {
            if (audioSource != null && collectResource != null)
            {
                audioSource.PlayOneShot(collectResource);
            }
        }

        ResourceManager.Instance.ChangeValue(value * multiplier, ResourceManager.Instance.GetColorFromEnum((int)color));
    }

}
