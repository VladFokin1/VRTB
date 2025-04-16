using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class KnobDeactivatorOnRotationY : MonoBehaviour
{
    [Header("Целевой угол по Y")]
    public float targetAngleY = -40f;

    [Tooltip("Допустимая погрешность")]
    public float tolerance = 5f;

    [Header("XR Knob (скрипт, который нужно отключить)")]
    public MonoBehaviour xrKnobScript; // можно использовать XRKnob, если ты знаешь точный тип

    
    public TaskManager manager;

    private bool hasTriggered = false;

    void Update()
    {
        if (hasTriggered) return;

        float currentY = NormalizeAngle(transform.localEulerAngles.y);

        if (Mathf.Abs(currentY - targetAngleY) <= tolerance)
        {
            if (xrKnobScript != null)
            {
                xrKnobScript.enabled = false;
                Debug.Log("XR Knob отключён");
            }

            if (manager != null)
            {
                manager.MarkTask(1, true);
                Debug.Log("Toggle включён");
            }

            hasTriggered = true;
        }
    }

    // Приводит угол к диапазону [-180, 180]
    float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
