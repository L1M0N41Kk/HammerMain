using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHightLight : MonoBehaviour
{
    public float swingHeight = 0.5f; // ������ �������
    public float swingSpeed = 1.0f; // �������� �������
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * swingSpeed) * swingHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
