using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIHammer : MonoBehaviour
{
    public HammerUse hammerUse;

    [Header("����������")]
    public TextMeshProUGUI hammerMagazine;
    public TextMeshProUGUI hammerAllDrop;
    public TextMeshProUGUI timerHammer;
    public TextMeshProUGUI hammerDamage;

    [Header("��������� ��� ��������")]
    public TextMeshProUGUI trowForce;
    [SerializeField] Slider trowForceSlider;
    [Space]
    public TextMeshProUGUI bounce;
    [SerializeField] Slider bounceSlider;
    [Space]
    public TextMeshProUGUI bounceForce;
    [SerializeField] Slider bounceForceSlider;
    [Space]
    public TextMeshProUGUI spin;
    [SerializeField] Slider spinSlider;
    [Space]
    public TextMeshProUGUI reload;
    [SerializeField] Slider reloadSlider;


    [Header("��������� ����������")]
    [TextArea(5,5)]
    [SerializeField] string info;
    [Tooltip("�� �������� �������� �������� � ������ ��������, �� ������� �� ���������! �����, �������� � �������� bounceSlider, �� 0 �� 20")]
    [Range(0, 20)]
    public int maxBounce;
    [Tooltip("�� �������� �������� �������� � ������ ��������, �� ������� �� ���������! �����, �������� � �������� bounceForceSlider, �� 0 �� 2")]
    [Range(0, 2)]
    public float bounceForceInstrument;
    [Tooltip("�� �������� �������� �������� � ������ ��������, �� ������� �� ���������! �����, �������� � �������� trowForceSlider, �� 0 �� 20")]
    [Range(0, 5)]
    public float massforce;
    [Tooltip("�� �������� �������� �������� � ������ ��������, �� ������� �� ���������! �����, �������� � �������� spinSlider, �� 0 �� 40")]
    [Range(0, 40)]
    public float angularSpin;
    [Tooltip("�� �������� �������� �������� � ������ ��������, �� ������� �� ���������! �����, �������� � �������� reloadSlider, �� 0 �� 10")]
    [Range(0, 10)]
    public float reloadTime;



    private void Awake()
    {
        //��� ���������� �������� �������, ���� ����� �� ����� �� ��� ��������� � ���� ������ � ������� � ���������� ��������
        maxBounce = 5;
        bounceForceInstrument = 0.4f;
        massforce = 1;
        angularSpin = 1.5f;
        reloadTime = 5f;

        trowForceSlider.value = massforce;
        bounceSlider.value = maxBounce;
        bounceForceSlider.value = bounceForceInstrument;
        spinSlider.value = angularSpin;
        reloadSlider.value = reloadTime;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        bounce.text = "�������� �������� " + maxBounce.ToString();
        trowForce.text = "��� ������� " + massforce.ToString();
        bounceForce.text = "���� ������� " + bounceForceInstrument.ToString();
        spin.text = "���� ������������ " + angularSpin.ToString();
        reload.text = "����� �����������" + hammerUse.reloadTime.ToString();
        timerHammer.text = hammerUse.reloadTimer.ToString();

        massforce = trowForceSlider.value;
        maxBounce = (int)bounceSlider.value;
        bounceForceInstrument = bounceForceSlider.value;
        angularSpin = spinSlider.value;
        hammerUse.reloadTime = reloadSlider.value;

        hammerMagazine.text = hammerUse.hammerCount.ToString();
        hammerAllDrop.text = hammerUse.allHammers.ToString();
        timerHammer.text = hammerUse.reloadTimer.ToString();
        hammerDamage.text = hammerUse.finalDamage.ToString();




    }
}
