using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public Button researchButton;
    public Button buildingButton;
    public static ButtonManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void HideButtons()
    {
        researchButton.gameObject.SetActive(false);
        buildingButton.gameObject.SetActive(false);

    }

    public void ShowButtons()
    {
        researchButton.gameObject.SetActive(true);
        buildingButton.gameObject.SetActive(true);

    }

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
