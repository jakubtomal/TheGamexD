using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "lvl 1")
        {
            Destroy(gameObject);
            Debug.Log("I am inside the if statement");
        }

        if (scene.name == "lvl Dziuk")
        {
            Destroy(gameObject);
            Debug.Log("I am inside the if statement");
        }
    }
}