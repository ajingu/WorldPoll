using System.Collections.Generic;
using UnityEngine;

public class RatioManager : MonoBehaviour {
    [SerializeField]
    KeyAndCount[] keyAndCount;

    static Dictionary<string, Dictionary<string, float>> ratios = new Dictionary<string, Dictionary<string, float>>();

    static int total = 0;

    void Start()
    {
        foreach (var element in keyAndCount)
        {
            ratios.Add(element.key, element.info);
        }
    }

    public static float GetRatio(string key)
    {
        if (ratios.ContainsKey(key))
        {
            return ratios[key]["ratio"];
        }
        else
        {
            return 0f;
        }
    }

    public static void UpdateRatio(string key)
    {
        if (ratios.ContainsKey(key))
        {
            ratios[key]["ratio"] = ++ratios[key]["count"] / ++total * 100f;
            RatioTextManager.SetRatioText(key, ratios[key]["ratio"]);
        }
    }
}
