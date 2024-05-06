using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private RowScript[] rows;
    [SerializeField] private SlotScript currentSlot;
    [SerializeField] private EndGameMenu endMenuToken;
    public TextMeshProUGUI wordToken;
    [SerializeField]private List<char> wordStorage = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    public List<char> word;
    public int rowIndex = 0;
    private int slotIndex = 0;
    public int correctness = 0;
    public Color correctColor;
    public Color wrongPosColor;
    public Color wrongColor;

    private void Awake()
    {
        rows = GetComponentsInChildren<RowScript>();
        wordToken.text = "";
        GenerateWord();
    }
    private void LateUpdate()
    {
        if (slotIndex < 5 && rowIndex < 6)
        {
            currentSlot = rows[rowIndex].slots[slotIndex];
            currentSlot.GetComponent<Outline>().effectColor = Color.red ;     
        }
    }

    public void InsertAlphabet(char letter)
    {
        Debug.Log("insert");
        if (slotIndex <= 4)
        {
            rows[rowIndex].slots[slotIndex].SetText(letter);
            currentSlot.GetComponent<Outline>().effectColor = new Color(0.5f, 0.5f, 0.5f);
            slotIndex++;
        }
    }

    public void DelteAlphabet()
    {
        Debug.Log("delete");
        if (slotIndex > 0)
        {
            slotIndex--;
        }
        rows[rowIndex].slots[slotIndex].SetText('\0');
        currentSlot.GetComponent<Outline>().effectColor = new Color(0.5f, 0.5f, 0.5f);
    }
    
    public void ConfirmAnswer()
    {
        Debug.Log("Confirmmmm");
        if (slotIndex == 5)
        {
            CompareWord();
            if (rowIndex < 5)
            {
                rowIndex++;
                slotIndex = 0;
            }
            else { rowIndex = 6; endMenuToken.gameObject.SetActive(true); }
        }
    }

    public void CompareWord()
    {
        correctness = 0;
        char  compareLetter;
        for (int i = 0; i < 5; i++)
        {
            compareLetter = rows[rowIndex].slots[i].letter;
            if (compareLetter == word[i])
            {
                rows[rowIndex].slots[i].GetComponent<Image>().color = correctColor;
                correctness++;
            }
            else if (word.Contains(compareLetter))
            {
                rows[rowIndex].slots[i].GetComponent<Image>().color = wrongPosColor;
            }
            else { rows[rowIndex].slots[i].GetComponent<Image>().color = wrongColor; }
        }
        if (correctness == 5) { endMenuToken.gameObject.SetActive(true); }
    }

    public void GenerateWord() 
    {
        int temp;
        for (int i = 0; i < 5; i++)
        {
            temp = Random.Range(0, wordStorage.Count);
            word.Add(wordStorage[temp]);
            wordStorage.RemoveAt(temp);
            wordToken.text += word[i];
        }
    }

}
