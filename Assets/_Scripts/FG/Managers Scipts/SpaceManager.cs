using System;
using UnityEngine;


public class SpaceManager : MonoBehaviour {
    public Camera mainCamera = null;
    public GameObject spaceBackground = null;
    public static SpaceManager instance = null;
    public float gameBackgroundSpeed = 1.0f;

    void Start ()
    {
        if (instance != null) return;
        instance = this;
    }
	

}
