using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PointCloudManager : Singleton<PointCloudManager> {
	
    public bool pointCloudIsVisible = false;
	public Vector3[] pointCloudData;

    private uint _numPointsToShow = 200;
    [SerializeField]
	private GameObject _pointCloudPrefab;
    private GameObject _pointCloudContainer;
    private List<GameObject> _pointCloudObjects;

	// Use this for initialization
	private void Start () {		
        if (pointCloudIsVisible)
            CreateVisiblePointCloud ();
	}

	private void OnEnable() {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
	}
	private void OnDisable() {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
	}

	public void ARFrameUpdated(UnityARCamera camera)
    {
        pointCloudData = camera.pointCloudData;

        // Updates the position of the gameobject point cloud represenatations
        if (pointCloudIsVisible)
		    UpdatePointCloudObjects();
    }

    public void Ping() {
        //Empty function to create an instance of this manager manually.
    }

	private void UpdatePointCloudObjects () {
		if (_pointCloudPrefab != null && pointCloudData != null)
        {
            for (int count = 0; count < Mathf.Min (pointCloudData.Length, _numPointsToShow); count++)
            {
                Vector4 vert = pointCloudData [count];

                // Check if the point cloud vertex has any invalid data, skip it if so
                if (float.IsNaN(vert.x) || float.IsNaN(vert.y) || float.IsNaN(vert.z) 
                    || float.IsInfinity(vert.x) || float.IsInfinity(vert.y) || float.IsInfinity(vert.x)
                    || float.IsNegativeInfinity(vert.x) || float.IsNegativeInfinity(vert.y) || float.IsNegativeInfinity(vert.z))
                    continue;
                GameObject point = _pointCloudObjects [count];
                point.transform.position = new Vector3(vert.x, vert.y, vert.z);
            }
        }
	}

    private void CreateVisiblePointCloud () {
        if (_pointCloudPrefab != null)
        {
            _pointCloudContainer = new GameObject("PointCloudContainer");
            _pointCloudObjects = new List<GameObject> ();
            for (int i =0; i < _numPointsToShow; i++)
            {
                _pointCloudObjects.Add (Instantiate (_pointCloudPrefab, _pointCloudContainer.transform));
            }
        }
    }
}
