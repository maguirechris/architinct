using UnityEngine;

public class Red : MonoBehaviour
{
    private void OnMouseDown()
    {
        ResourceManager.Instance.ChangeValue(1, "red");
        Debug.Log("Red tile clicked — added 1 to red");
    }
}
