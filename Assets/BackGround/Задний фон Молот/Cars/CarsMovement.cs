using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    public Transform[] pointsToFollow; // ������ �����, �� ������� ����� ��������� ������
    public float speed = 5.0f; // �������� ����������� ������

    private int currentPointIndex = 0; // ������� �����, � ������� �������� ������

    void Update()
    {
        if (currentPointIndex < pointsToFollow.Length)
        {
            Vector3 direction = pointsToFollow[currentPointIndex].position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, pointsToFollow[currentPointIndex].position) < 0.2f)
            {
                // ������� � ��������� �����
                currentPointIndex++;
            }
        }
        else
        {
            currentPointIndex = 0;
        }
    }
}
