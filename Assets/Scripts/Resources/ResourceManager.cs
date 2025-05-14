using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ResourceManager : MonoBehaviour
{
    private ResourceSO[] resources;
    public ResourceSO redSO, greenSO, blueSO;
    public static ResourceManager instance;
    public string red;
    public string green;
    public string blue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        resources.Append(redSO); 
        resources.Append(blueSO); 
        resources.Append(greenSO);
        red = redSO.resourceType;
        green = greenSO.resourceType;
        blue = blueSO.resourceType;
    }

    // Update is called once per frame
    void Update()
    {
        ResourceTick();
    }

    private ResourceSO ValidateResource(string color)
    {
        ResourceSO resource = null;
        foreach (ResourceSO r in resources)
        {
            if (r.resourceType == color)
            {
                resource = r;
                break;
            }
        }

        return resource;
    }

    private void ResourceTick()
    {
        foreach (ResourceSO resource in resources)
        {
            resource.value += resource.gainRate;
            if(resource.value > resource.limit)
            {
                resource.value = resource.limit;
            }
        }
    }

    void ChangeGainRate(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.gainRate += value;

    }


    void ChangeValue(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.value += value;

    }

    void ChangeLimit(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.limit += value;

    }

    float GetValue(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.value;
    }

    float GetGainRate(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.gainRate;
    }

    float GetLimit(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.limit;
    }
}
