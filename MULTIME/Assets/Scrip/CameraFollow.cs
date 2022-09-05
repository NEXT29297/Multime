using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D BoundsBox;
    private Vector3 minBounds;
    private Vector3 MaxBounds;
    
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        minBounds = BoundsBox.bounds.min;
        MaxBounds = BoundsBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, MaxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, MaxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        BoundsBox = newBounds;

        minBounds = BoundsBox.bounds.min;
        MaxBounds = BoundsBox.bounds.max;
    }
}
