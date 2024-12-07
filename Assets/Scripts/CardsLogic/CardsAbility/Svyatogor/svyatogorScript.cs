using UnityEngine;
using System.Collections.Generic;

public class svyatogorScript : MonoBehaviour
{
    public GameObject svyatogorSprite; // ������ ���������
    private int secondsCounter = 0; // ������� ������
    private float timeSinceLastSecond = 0f; // ����������� ����� ��� ������ ������
    private float baseChance = 1.0f; // ��������� ����
    private bool hasActivated = false; // ������������� �� ���� ��������
    public PlayerController playerController; // ������ �� PlayerController

    void Start()
    {
        secondsCounter = 0;
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (!playerController.isSvyatogorCardChosen || hasActivated)
            return;

        timeSinceLastSecond += Time.deltaTime;

        if (timeSinceLastSecond >= 1f)
        {
            secondsCounter++;
            timeSinceLastSecond -= 1f; // ��������� �� 1 �������
            if (ShouldActivate())
            {
                AttackEnemy();
            }
        }
    }

    private bool ShouldActivate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) return false; // ���� ������ ���, �� ���������� �����������

        float activationChance = Mathf.Min(baseChance + secondsCounter, 100f);
        float randomValue = Random.Range(0f, 100f);
        Debug.Log(activationChance);
        return randomValue <= activationChance;
    }

    public void AttackEnemy()
    {
        if (hasActivated) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> targets = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (IsVisible(enemy.transform))
            {
                targets.Add(enemy);
            }
        }

        if (targets.Count > 0)
        {
            GameObject randomEnemy = targets[Random.Range(0, targets.Count)];
            Vector3 enemyPosition = randomEnemy.transform.position;
            Vector3 spawnPosition = new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z);

            GameObject spawnedSprite = Instantiate(svyatogorSprite, spawnPosition, Quaternion.identity);
            Destroy(randomEnemy);
            StartCoroutine(DestroySpriteAfterDelay(spawnedSprite, 2f));
            hasActivated = true; 
        }
    }

    private System.Collections.IEnumerator DestroySpriteAfterDelay(GameObject sprite, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(sprite);
        ResetTimer(); // ��������� ������ ����� ����������� �������
    }

    private void ResetTimer()
    {
        secondsCounter = 0;
        timeSinceLastSecond = 0f;
        hasActivated = false; // ��������� ���� ��������� ������ ����� ����������� �������
    }

    // ��������, ����� �� ���� �� ������
    private bool IsVisible(Transform enemyTransform)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(enemyTransform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
