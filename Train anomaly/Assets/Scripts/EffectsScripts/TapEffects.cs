using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffects : MonoBehaviour
{
    public GameObject TapEffect;
    Vector2 mouse;
    public Camera uiCamera;
    private void Start()
    {
        TapEffect.SetActive(false);
    }
    void Update()
    {
        ClickEffector();
    }

    public void ClickEffector()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию мыши на экране
            mouse = Input.mousePosition;

            // Преобразуем экранные координаты в локальные координаты канваса
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                GetComponent<RectTransform>(), // RectTransform канваса
                mouse, // Позиция мыши
                uiCamera, // Используем заданную камеру
                out Vector2 localPoint // Выходной параметр для локальной позиции
            );

            // Активируем эффект частиц и устанавливаем его позицию
            TapEffect.SetActive(true);
            TapEffect.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            TapEffect.SetActive(false);
        }

    }
}
