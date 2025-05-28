using UnityEngine;

public class Green : MonoBehaviour
{
    private void OnMouseDown()
    {
        ResourceManager.Instance.ChangeValue(1, "green");
        Debug.Log("Green tile clicked — added 1 to red");
    }
}
