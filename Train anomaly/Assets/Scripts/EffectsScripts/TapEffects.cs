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
            // �������� ������� ���� �� ������
            mouse = Input.mousePosition;

            // ����������� �������� ���������� � ��������� ���������� �������
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                GetComponent<RectTransform>(), // RectTransform �������
                mouse, // ������� ����
                uiCamera, // ���������� �������� ������
                out Vector2 localPoint // �������� �������� ��� ��������� �������
            );

            // ���������� ������ ������ � ������������� ��� �������
            TapEffect.SetActive(true);
            TapEffect.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            TapEffect.SetActive(false);
        }

    }
}
