using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BiggerFlashlight : MonoBehaviour
{
    Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
    }

    public void IncreaseFlashlight()
    {
        light.pointLightOuterAngle += 6;
        light.pointLightInnerAngle += 6;
    }


}

