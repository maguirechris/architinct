using UnityEngine;

public static class MenuManager
{
    private static IMenu primaryMenu = null;
    private static IMenu overlayMenu = null;

    public static void OpenPrimaryMenu(IMenu newMenu) {
        if (primaryMenu != null)
        {
            primaryMenu.Close();
        }

        primaryMenu = newMenu;
        primaryMenu.Open();
    }

    public static void ClosePrimaryMenu() {
        if (primaryMenu != null)
        {
            primaryMenu.Close();
            primaryMenu = null;
        }
    }

    public static bool IsPrimaryMenuOpen() {
        return primaryMenu != null;
    }

    public static void OpenOverlayMenu(IMenu newOverlay) {
        if (overlayMenu != null)
        {
            overlayMenu.Close();
        }

        overlayMenu = newOverlay;
        overlayMenu.Open();
    }

     public static void CloseOverlayMenu()
    {
        if (overlayMenu != null)
        {
            overlayMenu.Close();
            overlayMenu = null;
        }
    }

    public static bool IsOverlayMenuOpen()
    {
        return overlayMenu != null;
    }

    public static bool IsAnyMenuOpen()
    {
        return primaryMenu != null || overlayMenu != null;
    }

    public static IMenu GetCurrentPrimaryMenu()
    {
        return primaryMenu;
    }
}
