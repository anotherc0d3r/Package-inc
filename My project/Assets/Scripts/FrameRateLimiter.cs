using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    void Start()
    {
        // Set target frame rate to 60 FPS
        Application.targetFrameRate = 60;
    }
}
