using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using System;

public class ARPlaneManager : Singleton<ARPlaneManager> {
	[SerializeField]
	private GameObject _planePrefab;
    [SerializeField]
    private Material _hiddenPlaneMaterial;
    private Material _defaultPlaneMaterial;

	private Dictionary<string, PlaneAnchor> _storedPlaneAnchors;

	
	void Awake () {
        if (_planePrefab == null)
            throw new NullReferenceException ("ARPlaneManager: Missing plane prefab reference...");
        if (_hiddenPlaneMaterial == null) 
            throw new NullReferenceException ("ARPlaneManager: Missing hidden material reference...");

        _defaultPlaneMaterial = Utilities.GetDefaultObjectMaterial (_planePrefab);

		_storedPlaneAnchors = new Dictionary<string, PlaneAnchor> ();
		UnityARSessionNativeInterface.ARAnchorAddedEvent += OnPlaneAdded;
		UnityARSessionNativeInterface.ARAnchorUpdatedEvent += OnPlaneUpdated;
		UnityARSessionNativeInterface.ARAnchorRemovedEvent += OnPlaneRemoved;
	}

	public void OnPlaneAdded (ARPlaneAnchor anchor) {
		if (!_storedPlaneAnchors.ContainsKey (anchor.identifier)) {
			var planeAnchor = new PlaneAnchor (anchor, Instantiate(_planePrefab)); 
			_storedPlaneAnchors.Add (anchor.identifier, planeAnchor);
		}
	}

	public void OnPlaneRemoved (ARPlaneAnchor anchor) {
		Destroy (_storedPlaneAnchors[anchor.identifier].planeObject);
		_storedPlaneAnchors.Remove (anchor.identifier);
	}

	public void OnPlaneUpdated (ARPlaneAnchor anchor) {
		if (_storedPlaneAnchors.ContainsKey (anchor.identifier)) {
			_storedPlaneAnchors[anchor.identifier].UpdateAnchor (anchor);
		}
	}

    public void ApplyHiddenPlaneMaterial () {
        foreach (var kvp in _storedPlaneAnchors) {
            kvp.Value.ApplyMaterial(_hiddenPlaneMaterial);
        }
    }

    public void ApplyDefaultPlaneMaterial () {
        foreach (var kvp in _storedPlaneAnchors)
        {
            kvp.Value.ApplyMaterial(_defaultPlaneMaterial);
        }
    }
}
