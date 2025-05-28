using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ResearchUI : MonoBehaviour
{
    public Research research;
    public Button button;
    public Image frame;
    public Image buildingImage;
    public Image lockPanel;
    public Image lockImage;
    public Material lineMat;
    public LineRenderer[] lines;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float costTotal = research.cost.red + research.cost.green + research.cost.blue;
        if (costTotal < 0)
        {
            costTotal = 1;
        }
        float redRatio = research.cost.red / costTotal;
        float greenRatio = research.cost.green / costTotal;
        float blueRatio = research.cost.blue / costTotal;
        frame.color = new Color(redRatio * 255, greenRatio * 255, blueRatio * 255);

        lockPanel.gameObject.SetActive(true);

        for(int i = 0; i < research.unlocks.Length; i++)
        {
            GameObject lineChild = new GameObject();
            lineChild.name = "Line " + i;
            lineChild.transform.SetParent(transform);
            LineRenderer line = lineChild.AddComponent<LineRenderer>();
            line.positionCount = 2;
            line.widthMultiplier = 0.5f;
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, research.unlocks[i].gameObject.transform.position);
            line.startColor = frame.color;
            line.endColor = research.unlocks[i].gameObject.GetComponent<ResearchUI>().frame.color;
            line.material = lineMat;
            line.useWorldSpace = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = !research.locked && ResourceManager.Instance.CanPay(research.cost) && !research.researched;
        float costTotal = research.cost.red + research.cost.green + research.cost.blue;
        if (costTotal <= 0)
        {
            costTotal = 1;
        }
        float redRatio = research.cost.red / costTotal;
        float greenRatio = research.cost.green / costTotal;
        float blueRatio = research.cost.blue / costTotal;
        if (redRatio == greenRatio && greenRatio == blueRatio)
        {
            redRatio = 1;
            greenRatio = 1;
            blueRatio = 1;
        }

        frame.color = new Color(redRatio, greenRatio, blueRatio);
        lockPanel.enabled = research.researched || research.locked;
        lockImage.enabled = research.locked;

        for(int i = 0; i < lines.Length; i++)
        {
            LineRenderer line = lines[i];
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, research.unlocks[i].gameObject.transform.position);
        }
    }


}
