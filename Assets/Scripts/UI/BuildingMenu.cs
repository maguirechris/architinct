using UnityEngine;

public class BuildlingScript : MonoBehaviour
{
    public GameObject buildingMenu;
    public GameObject tileMap;
    public GameObject resources;

    void Update() {
        if (Input.GetKey(KeyCode.B)) {
            openMenu();
        }
    }

    public void openMenu()
    {
        buildingMenu.SetActive(true);
        tileMap.SetActive(false);
        resources.SetActive(false);
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        buildingMenu.SetActive(false);
        tileMap.SetActive(true);
        resources.SetActive(true);
        Time.timeScale = 1;
    }
}
