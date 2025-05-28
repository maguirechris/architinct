using UnityEngine;

public class BuildlingScript : MonoBehaviour
{
    public GameObject buildingMenu;

    void Update() {
        if (Input.GetKey(KeyCode.B)) {
            openMenu();
        }
    }

    public void openMenu() {
        buildingMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        buildingMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
