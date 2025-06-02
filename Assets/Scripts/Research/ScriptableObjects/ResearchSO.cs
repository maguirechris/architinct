using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "Scriptable Objects/Resource")]
public class ResearchSO : ScriptableObject
{
    public float valueMod = 0f;
    public float valueMult = 1f;
    public float costRMult = 0f;
    public float costGMult = 0f;
    public float costBMult = 0f;
}
