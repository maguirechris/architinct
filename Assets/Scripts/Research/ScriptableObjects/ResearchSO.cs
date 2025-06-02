using UnityEngine;

[CreateAssetMenu(fileName = "New Research", menuName = "Scriptable Objects/Research")]
public class ResearchSO : ScriptableObject
{
    public float valueMod = 0f;
    public float valueMult = 0f;
    public float costRMult = 1f;
    public float costGMult = 1f;
    public float costBMult = 1f;
}
