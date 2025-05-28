using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.VisualScripting.StickyNote;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    private List<ResourceSO> resources = new();
    public ResourceSO redSO, greenSO, blueSO;
    public static ResourceManager Instance;
    [HideInInspector] public string red, green, blue;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resources.Add(redSO); 
        resources.Add(blueSO); 
        resources.Add(greenSO);
        red = redSO.resourceType;
        green = greenSO.resourceType;
        blue = blueSO.resourceType;

        ResetResources();
    }

    // Update is called once per frame
    void Update()
    {
        ResourceTick();
    }

    private void ResetResources()
    {
        foreach (ResourceSO r in resources)
        {
            r.value = 0;
            r.gainRate = 0;
            r.limit = 500;
        }
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
            resource.value += resource.gainRate * Time.deltaTime;
            if(resource.value > resource.limit)
            {
                resource.value = resource.limit;
            }
        }
    }

    public string GetColorFromEnum(int colorEnum)
    {
        return resources[colorEnum].resourceType;
    }

    public void ChangeGainRate(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.gainRate += value;

    }


    public void ChangeValue(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.value += value;

    }

    public void ChangeLimit(float value, string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.limit += value;

    }

    public float GetValue(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.value;
    }

    public float GetGainRate(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.gainRate;
    }

    public float GetLimit(string color)
    {
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.limit;
    }

    public void ChangeGainRate(float value, int colorEnum)
    {
        
        string color = GetColorFromEnum(colorEnum);

        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.gainRate += value;

    }


    public void ChangeValue(float value, int colorEnum)
    {

        string color = GetColorFromEnum(colorEnum);
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.value += value;

    }

    public void ChangeLimit(float value, int colorEnum)
    {

        string color = GetColorFromEnum(colorEnum);
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return;
        }

        resource.limit += value;

    }

    public float GetValue(int colorEnum)
    {

        string color = GetColorFromEnum(colorEnum);
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.value;
    }

    public float GetGainRate(int colorEnum)
    {

        string color = GetColorFromEnum(colorEnum);
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.gainRate;
    }

    public float GetLimit(int colorEnum)
    {

        string color = GetColorFromEnum(colorEnum);
        ResourceSO resource = ValidateResource(color);

        if (resource == null)
        {
            Debug.Log("Invalid resource!");
            return 0;
        }

        return resource.limit;
    }

    public void Pay(Cost cost)
    {

        float r = cost.red;
        float g = cost.green;
        float b = cost.blue;

        if (CanPay(cost))
        {
            redSO.value -= r;
            greenSO.value -= g;
            blueSO.value -= b;
        }

    }

    public bool CanPay(Cost cost)
    {
        float r = cost.red;
        float g = cost.green;
        float b = cost.blue;

        if (redSO.value >= r && greenSO.value >= g && blueSO.value >= b)
        {
            return true;
        }
        return false;
    }

}
