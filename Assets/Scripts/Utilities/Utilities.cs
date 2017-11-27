using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Utilities {

    public static Material GetDefaultObjectMaterial (GameObject go) {
        MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
        if (mr == null)
            throw new NullReferenceException ("Utilities: MeshRenderer for passed object is null...");

        return mr.sharedMaterial;
    }
}
