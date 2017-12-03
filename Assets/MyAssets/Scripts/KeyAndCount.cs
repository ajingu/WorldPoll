using System;
using System.Collections.Generic;

[Serializable]
public class KeyAndCount {
    public string key;
    public Dictionary<string, float> info = new Dictionary<string, float>(){
        { "count", 0f },
        { "ratio", 0f }
    };
}
