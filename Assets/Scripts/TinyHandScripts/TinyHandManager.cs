using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class TinyHandManager : Singleton<TinyHandManager>
{

    private List<GameObject> _tinyHandList;
    private TinyHandFactory _tinyHandFactory;
    private int _tinyHandMax = 15;

    private void Awake()
    {
        _tinyHandList = new List<GameObject>();
        _tinyHandFactory = gameObject.AddComponent<TinyHandFactory>();

        InputManager.Instance.ARTouchBeganUpdateEvent += OnTouchBegan;
    }

    public void InstantiateTinyHand(Vector3 pos)
    {
        if (_tinyHandList.Count > _tinyHandMax) {
            Destroy(_tinyHandList[0]);
            _tinyHandList.RemoveAt(0);
        }

        var tinyHand = _tinyHandFactory.GetTinyHand();
        _tinyHandList.Add(tinyHand);

        tinyHand.transform.position = pos;
    }

    public void ClearTinyHands()
    {
        foreach (var go in _tinyHandList)
        {
            Destroy(go);
        }

        _tinyHandList.Clear();
    }

    public void OnTouchBegan(Touch touch)
    {
#if UNITY_EDITOR
        var ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit)) {
            InstantiateTinyHand(hit.point);
        }
#else
        var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);

        ARPoint point = new ARPoint
        {
            x = screenPosition.x,
            y = screenPosition.y
        };

        // use arkit hit test to find planes
        List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point,
                    ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
        if (hitResults.Count > 0)
        {
            foreach (var hitResult in hitResults)
            {
                Vector3 position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                InstantiateTinyHand(new Vector3(position.x, position.y, position.z));
                break;
            }
        }
#endif
    }
}
