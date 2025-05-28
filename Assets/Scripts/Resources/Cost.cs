using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cost : MonoBehaviour
{
    public float red, green, blue;

    public float GetValue(int colorEnum)
    {

        if (colorEnum == 0)
        {
            return red;
        }
        else if (colorEnum == 2)
        {
            return green;
        }
        else if (colorEnum == 1)
        {
            return blue;
        }

        return 0;
    }
}
