using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeModifier : MonoBehaviour {

    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = transform.localScale;
    }

    public void Bigger() {
        transform.localScale *= 1.2f;
        print("bigger");
    }

    public void Reset() {
        transform.localScale = _defaultScale;
        print("reset");
    }

    public void Smaller()
    {
        transform.localScale *= 0.8f;
        print("smaller");
    }
}
