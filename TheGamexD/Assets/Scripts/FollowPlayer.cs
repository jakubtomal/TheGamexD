using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;
    [SerializeField]
    private float cameraSpeed;
    private Vector3 newCameraPosition = Vector3.zero;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        transform.position = CalculateCameraPosition();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,CalculateCameraPosition(),cameraSpeed);
    }

    private Vector3 CalculateCameraPosition()
    {
        newCameraPosition = player.transform.position;
        newCameraPosition.z -= zOffset;
        newCameraPosition.y += yOffset;
        return newCameraPosition;
    }
}
