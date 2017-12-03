using System.Collections;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    [SerializeField]
    GameObject arrowPrefab;

    [SerializeField]
    Transform parentTransform;

    public void makeArrow(Vector3 pos, Quaternion q) {
        GameObject go = (GameObject)Instantiate(arrowPrefab, pos, q);
        go.transform.parent = parentTransform;
    }
}
