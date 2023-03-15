using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerJump : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public GameObject player;
    public float yMin = 0;
    public float yMax = 1;

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                // Get the y-position of the detected marker
                float markerYPosition = trackedImage.transform.position.y;
                // Use the y-position of the detected marker for any desired actions or calculations
                Debug.Log("Marker Y-position: " + markerYPosition);

                // Calculate the y-position of the Player object within the desired range
                float yPosition = Mathf.Clamp((markerYPosition * 50), yMin, yMax);

                // Set the y-position of the Player object
                Vector3 playerPosition = player.transform.position;
                playerPosition.y = yPosition;
                player.transform.position = playerPosition;
            }
        }
    }
}
