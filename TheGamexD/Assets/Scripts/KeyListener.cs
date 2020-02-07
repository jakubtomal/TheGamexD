using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour {
    [SerializeField] SceneLoader sceneLoader;


    // Update is called once per frame
    void Update() {
        if (Input.anyKey) {
            sceneLoader.LoadStartScene();
        }

    }
}
