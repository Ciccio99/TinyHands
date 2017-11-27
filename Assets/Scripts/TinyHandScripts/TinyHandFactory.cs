using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TinyHandFactory : MonoBehaviour {

    private GameObject _tinyHandPrefab;
    private GameObject _tweetContainerPrefab;
    private float _heightFudgeFactor = 0.25f;

    private void Awake()
    {
        _tinyHandPrefab = Resources.Load<GameObject>(Constants.tinyHand_prefab_path);
        _tweetContainerPrefab = Resources.Load<GameObject>(Constants.tweetContainer_prefab_path);
    }

    public GameObject GetTinyHand () {
        
        return ConstructTinyHand();
    }

    private GameObject ConstructTinyHand () {
        var hand = Instantiate(_tinyHandPrefab);
        ApplyRandomYRotation(hand);

        var tweet = Instantiate(_tweetContainerPrefab);
        var pos = tweet.transform.position;
        tweet.transform.position = new Vector3 (pos.x, pos.y + _heightFudgeFactor, pos.z);

        var tm = tweet.GetComponentInChildren<TextMeshPro>();
        tm.SetText(TweetLibrary.GetRandomTweet());

        var finalGO = new GameObject("TrumpHandWithTweet");

        // Set the parent to
        hand.transform.SetParent(finalGO.transform);
        tweet.transform.SetParent(finalGO.transform);

        return finalGO;
    }

    private void ApplyRandomYRotation (GameObject go) {
        var randRot = Random.Range(0, 360);
        Quaternion finalRotation = Quaternion.AngleAxis(randRot, Vector3.up);

        go.transform.rotation = finalRotation;
    }
}
