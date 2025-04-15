using UnityEngine;
using UnityEngine.UI;

public class PlaneObjectChecker : MonoBehaviour
{
    public Collider planeArea;           // Коллайдер плоскости
    public Toggle targetToggle;          // Тоггл для обновления
    public float checkHeight = 10f;      // Высота вверх от плоскости, в которой ищем объекты
    public LayerMask objectLayerMask;    // Слои объектов, которые нужно учитывать

    void Update()
    {
        CheckAbovePlane();
    }

    void CheckAbovePlane()
    {
        Bounds bounds = planeArea.bounds;

        Vector3 boxCenter = new Vector3(bounds.center.x, bounds.max.y + checkHeight / 2f, bounds.center.z);
        Vector3 boxSize = new Vector3(bounds.size.x, checkHeight, bounds.size.z);

        Collider[] hits = Physics.OverlapBox(boxCenter, boxSize / 2f, Quaternion.identity, objectLayerMask);

        // true — если ничего нет над плоскостью
        targetToggle.isOn = hits.Length == 0;
    }

    void OnDrawGizmosSelected()
    {
        if (planeArea != null)
        {
            Bounds bounds = planeArea.bounds;
            Vector3 boxCenter = new Vector3(bounds.center.x, bounds.max.y + checkHeight / 2f, bounds.center.z);
            Vector3 boxSize = new Vector3(bounds.size.x, checkHeight, bounds.size.z);

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(boxCenter, boxSize);
        }
    }
}