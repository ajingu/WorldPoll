using System.Collections.Generic;
using UnityEngine;

public class RatioTextManager : MonoBehaviour {

    [SerializeField]
    KeyAndUI[] keyAndUI;

    static Dictionary<string, TextMesh> texts = new Dictionary<string, TextMesh>();

    void Start () {
        foreach (var element in keyAndUI) {
            texts.Add(element.key, element.text);
        }
	}

    public static void SetRatioText(string key, float ratio) {
        texts[key].text = ratio + "%";
    }
}
