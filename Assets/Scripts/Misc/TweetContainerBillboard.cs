using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetContainerBillboard : MonoBehaviour {

    private Transform _mainCameraTransform;

    private void Awake()
    {
        _mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update () {
        var targetPos = new Vector3(_mainCameraTransform.position.x,
                                  transform.position.y,
                                  _mainCameraTransform.position.z);        
        transform.LookAt(targetPos);
        transform.Rotate(new Vector3(0f, 180f, 0f)) ;
	}
}
