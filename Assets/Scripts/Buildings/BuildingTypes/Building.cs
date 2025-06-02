using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour
{


    public float value;
    public float multiplier;
    public Cost cost;

    public float ApplyResearch(ResearchSO research)
    {
        float oldval = value * multiplier;
        value += research.valueMod;
        multiplier += research.valueMult;
        cost.red *= research.costRMult;
        cost.green *= research.costGMult;
        cost.blue *= research.costBMult;
        return oldval;
    }

    public virtual void OnUpgrade(float oldValue) { }

}
