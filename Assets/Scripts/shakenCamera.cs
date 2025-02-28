using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0f;  // Duration of the shake
    public float shakeMagnitude = 0.1f;  // Magnitude of the shake
    public float shakeSpeed = 0.1f;  // Speed of the shake

    private Vector3 originalCameraPosition;
    private float shakeTimeRemaining = 0f;

    void Start()
    {
        originalCameraPosition = transform.position;  // Store the initial camera position
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            float shakeAmountX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float shakeAmountY = Random.Range(-shakeMagnitude, shakeMagnitude);

            // Apply the random shake to the camera position
            transform.position = new Vector3(originalCameraPosition.x + shakeAmountX, originalCameraPosition.y + shakeAmountY, originalCameraPosition.z);
            shakeTimeRemaining -= Time.deltaTime * shakeSpeed;
        }
        else
        {
            transform.position = originalCameraPosition;  // Reset to original position of camera
        }
    }

    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        shakeTimeRemaining = shakeDuration;
    }
}
