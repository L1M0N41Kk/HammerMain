using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoController : MonoBehaviour
{
    public GameObject piano; // ������ �����
    private int secondsCounter = 0; // ������� ������
    private float timeSinceLastSecond = 0f; // ����������� ����� ��� ������ ������
    private float baseChance = 1.0f; // ��������� ����
    private bool hasActivated = false; // �������������� �� �����
    public PlayerController playerController; // ������ �� PlayerController
    public Transform[] linePoints;
    private GameObject activePiano;

    void Start()
    {
        secondsCounter = 0;
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        linePoints = new Transform[2];
        linePoints[0] = GameObject.Find("RightPoint_piano").transform;
        linePoints[1] = GameObject.Find("LeftPoint_piano").transform;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (!playerController.isPianoCardChosen || activePiano != null)
            return; //�� �������� ������, ���� ��� ���� �������� �����

        timeSinceLastSecond += Time.deltaTime;

        //��������� ����������� ��������� �����������
        if (timeSinceLastSecond >= 1f)
        {
            secondsCounter++;
            timeSinceLastSecond -= 1f; // ��������� �� 1 �������

            if (!hasActivated && ShouldActivate())
            {
                AttackEnemy();
            }
        }
    }

    public bool ShouldActivate()
    {
        //������������ ���� ���������
        float activationChance = Mathf.Clamp(baseChance + secondsCounter, 1f, 100f);
        float randomValue = Random.Range(0f, 100f);

        Debug.Log(activationChance);

        return randomValue <= activationChance;
    }

    public void AttackEnemy()
    {
        if (activePiano != null)
            return; // ���� ����� ��� �������, ������ �� ������

        int randomIndex = Random.Range(0, linePoints.Length);
        Transform spawnPoint = linePoints[randomIndex];
        activePiano = Instantiate(piano, spawnPoint.position, Quaternion.identity);
        hasActivated = true; // ������������� ���� ��������� ����� ������
        ResetActivationChance();
        playerController.pianoCardPoint++;
    }

    public void PianoDestroyed()
    {
        activePiano = null;
        ResetActivationChance();
    }

    private void ResetActivationChance()
    {
        secondsCounter = 0;
        hasActivated = false; //����� ����� ���������
        baseChance = 1.0f; //����� ����� � 1% ����� ������ �����
    }
}
