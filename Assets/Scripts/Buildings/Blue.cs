using UnityEngine;

public class Blue : MonoBehaviour
{
    private void OnMouseDown()
    {
        ResourceManager.Instance.ChangeValue(1, "blue");
        Debug.Log("Blue tile clicked — added 1 to red");
    }
}
