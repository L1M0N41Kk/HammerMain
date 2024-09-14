using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPanel : MonoBehaviour
{
    public GameObject cardPanel;
    public List<GameObject> cardPool;
    public List<GameObject> displayedCards;
    public List<Transform> cardSlots;

    public bool isGamePaused = false;
    public HammerUse hammerUse;

    void Start()
    {
        cardPanel.SetActive(false);
        hammerUse = GameObject.Find("HammerControll").GetComponent<HammerUse>();
    }

    public void OnButtonClick()
    {
        cardPanel.SetActive(true); //���������� ������
        PauseGame();

        // ����� ��������� ���� �� ������� ��������
        displayedCards.Clear();
        ShuffleCardPool();
        for (int i = 0; i < 3; i++)
        {
            GameObject randomCard = Instantiate(cardPool[i]);
            randomCard.SetActive(true);
            displayedCards.Add(randomCard);

            if (i < cardSlots.Count)
            {
                // ������������� �������� ��� �������� ���� ������� �������
                randomCard.transform.SetParent(cardSlots[i]);
                randomCard.transform.localPosition = Vector3.zero;
                
                // ��������� ���������� ������ (� ��������) ����������� �������� ����� 
                Button cardButton = randomCard.GetComponent<Button>();
                if (cardButton != null)
                {
                    cardButton.onClick.AddListener(() => OnCardClick(randomCard));

                }
            }
        }
    }

    public void OnCardClick(GameObject clickedCard)
    {
        cardPanel.SetActive(false);
        //�������� ������ � �������, ����� �� ������� ����� �� ���
        ResumeGame();

        foreach (GameObject card in displayedCards)
        {
            // ���������� ����� �������� ��� �������� ������
            Destroy(card);
        }
    }

    private void ShuffleCardPool()
    {
        //������������ ��������� ���� (����������)
        for (int i = 0; i < cardPool.Count; i++)
        {
            GameObject temp = cardPool[i];
            int randomIndex = Random.Range(i, cardPool.Count);
            cardPool[i] = cardPool[randomIndex];
            cardPool[randomIndex] = temp;
        }
    }

    //����� � ���� (����� ������, ����� ������� �� ��������)
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        hammerUse.useHammer= false;
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        hammerUse.useHammer = true;
    }
}
