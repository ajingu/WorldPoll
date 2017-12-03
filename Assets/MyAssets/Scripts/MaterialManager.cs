using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class MaterialManager : MonoBehaviour
    {

        [SerializeField]
        KeyAndMaterial[] keyAndMaterial;

        static Dictionary<string, Material> materials = new Dictionary<string, Material>();

        void Start()
        {
            foreach (var element in keyAndMaterial)
            {
                materials.Add(element.key, element.material);
            }
        }

        public static Material GetMaterial(string key)
        {
            Material _material;

            if (materials.ContainsKey(key))
            {
                materials.TryGetValue(key, out _material);
            }
            else
            {
                return null;
            }

            return _material;
        }
    }
}
