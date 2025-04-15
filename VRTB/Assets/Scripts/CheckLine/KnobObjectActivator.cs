using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KnobObjectActivator : MonoBehaviour
{
    [Header("Knob объект")]
    public Transform knobTransform;
    public RollsManager manager;

    [Header("Порог активации")]
    [Tooltip("Насколько близко к 180° нужно повернуть, чтобы активировать")]
    public float activationTolerance = 20f; // Например, ±20°

    [Header("Объекты для активации")]
    public GameObject[] objectsToActivate;

    [Header("XR Кнопки (Interactables)")]
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable[] vrButtons;

    void Update()
    {
        float angle = NormalizeAngle(knobTransform.localEulerAngles.y); // Получаем угол в диапазоне [0, 360]

        bool shouldActivate = Mathf.Abs(angle - 180f) <= activationTolerance;

        // Активируем / деактивируем объекты
        foreach (var obj in objectsToActivate)
            if (obj != null)
                obj.SetActive(shouldActivate);

        // Активируем / деактивируем кнопки
        foreach (var button in vrButtons)
            if (button != null)
                button.enabled = shouldActivate;
        if (!shouldActivate) {
            manager.Disable();
        }
    }

    // Возвращает угол в диапазоне [0, 360]
    float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle < 0f) angle += 360f;
        return angle;
    }
}