using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public BuffPanel buffPanel;
    public void Start()
    {
        buffPanel = GameObject.Find("CardManager").GetComponent<BuffPanel>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        buffPanel.cardSlots.Add(transform); // ��������� ���� ���� � ������ ������ � ������ CardGame
    }

    private void OnDisable()
    {
        buffPanel.cardSlots.Remove(transform); // ������� ���� ���� �� ������ ������ ��� ��� ����������
    }
}
