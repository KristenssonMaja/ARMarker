using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    private float markerYPosition;

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
                markerYPosition = trackedImage.transform.position.y;
                
                // Use the y-position of the detected marker for any desired actions or calculations
                Debug.Log("Marker Y-position: " + markerYPosition);
            }
        }
    }
}
