using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;
    float shakeDuration;
    float shakeMagnitude;

    private float shakeTimeRemaining;
    private Vector3 originalPosition;

    Vector3 offset = new Vector3(0f, 0f, -10f);

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;



        if (shakeTimeRemaining > 0)
        {
            desiredPosition += GetShakeOffset();
            shakeTimeRemaining -= Time.fixedDeltaTime;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    public void TriggerShake(float duration, float magnitude)
    {
        shakeTimeRemaining = duration;
        shakeMagnitude = magnitude;
    }
    private Vector3 GetShakeOffset()
    {
        float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
        float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;
        return new Vector3(offsetX, offsetY, 0f);
    }

}
