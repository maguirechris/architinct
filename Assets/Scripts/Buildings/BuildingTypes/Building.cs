using UnityEngine;

public class Building : MonoBehaviour
{

    public float value;
    public Cost cost;

    public void ApplyResearch(ResearchSO research)
    {
        value += research.valueMod;
        value *= research.valueMult;
        cost.red *= research.costRMult;
        cost.green *= research.costGMult;
        cost.blue *= research.costBMult;
    }

}
