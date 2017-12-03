using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Utils;
public class PositionDeterminer : MonoBehaviour
{
    [SerializeField]
    private AbstractMap _map;

    [SerializeField]
    FlatSphereTerrainFactory _globeFactory;

    [SerializeField]
    private ILocationProvider _locationProvider;

    [SerializeField]
    private GameObject _markPrefab;

    [SerializeField]
    ArrowManager arrowManager;

    private Vector2d _currentLocation;
    private Vector3 _targetPosition;

    public void Arrange(Material _material)
    {
        Vector3 pos = RetrievePosition();
        GameObject go = (GameObject)Instantiate(_markPrefab, pos, Quaternion.identity);
        go.GetComponent<Renderer>().material = _material;
        go.transform.parent = _map.gameObject.transform;
        Vector3 normal = (pos - _map.transform.position).normalized;
        arrowManager.makeArrow(pos + normal * 0.05f, Quaternion.LookRotation(normal)*Quaternion.Euler(-90f, 0f, 0f));
    }
    Vector3 RetrievePosition()
    {
#if UNITY_IOS
        var lastData = Input.location.lastData;
        _currentLocation = new Vector2d (lastData.latitude, lastData.longitude);
#else
        _currentLocation = new Vector2d(35.662968, 139.567926);
#endif
        _targetPosition = _map.transform.rotation * Conversions.GeoToWorldGlobePosition(_currentLocation, _globeFactory.Radius) + _map.transform.position;

        return _targetPosition;
    }
}

