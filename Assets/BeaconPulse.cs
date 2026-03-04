using UnityEngine;

public class BeaconPulse : MonoBehaviour
{
    [Header("References")]
    public Transform halo;
    public Renderer coreRenderer;
    public Renderer haloRenderer;
    public Transform cameraTransform;

    [Header("Pulse")]
    public float pulseSpeed = 1.6f;
    public float haloMinScale = 2.0f;
    public float haloMaxScale = 3.2f;

    [Header("Brightness")]
    public float coreMin = 1.2f;
    public float coreMax = 2.5f;
    public float haloMinAlpha = 0.08f;
    public float haloMaxAlpha = 0.22f;

    Color coreBase;
    Color haloBase;

    void Awake()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (coreRenderer != null)
            coreBase = coreRenderer.material.color;

        if (haloRenderer != null)
            haloBase = haloRenderer.material.color;
    }

    void LateUpdate()
    {
        // Face camera
        if (halo != null && cameraTransform != null)
        {
            halo.LookAt(cameraTransform);
        }

        // Pulse 0..1
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;

        // Halo scale pulse
        if (halo != null)
        {
            float s = Mathf.Lerp(haloMinScale, haloMaxScale, t);
            halo.localScale = new Vector3(s, s, s);
        }

        // Core brightness pulse
        if (coreRenderer != null)
        {
            float b = Mathf.Lerp(coreMin, coreMax, t);
            coreRenderer.material.color = new Color(coreBase.r * b, coreBase.g * b, coreBase.b * b, 1f);
        }

        // Halo alpha pulse
        if (haloRenderer != null)
        {
            float a = Mathf.Lerp(haloMinAlpha, haloMaxAlpha, t);
            haloRenderer.material.color = new Color(haloBase.r, haloBase.g, haloBase.b, a);
        }
    }
}