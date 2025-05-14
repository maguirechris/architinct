using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "Scriptable Objects/Resource")]
public class ResourceSO : ScriptableObject
{
    public float value = 0;
    public float limit = 0;
    public float gainRate = 0;
    public string resourceType;

}
