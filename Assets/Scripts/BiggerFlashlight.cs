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
        light.pointLightOuterAngle += 15;
        light.pointLightInnerAngle += 15;
    }


}

