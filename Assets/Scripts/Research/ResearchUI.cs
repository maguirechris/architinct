using UnityEngine;
using UnityEngine.UI;

public class ResearchUI : MonoBehaviour
{
    public Research research;
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = !research.locked && ResourceManager.Instance.CanPay(research.cost) && !research.researched;
    }

}
