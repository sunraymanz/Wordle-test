using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonData : MonoBehaviour
{
    [SerializeField] private char[] buttonText;
    public bool isEnter;
    public bool isDel;
    // Start is called before the first frame update
    void Start()
    {
        if (!isEnter && !isDel)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>().text.ToLower().ToCharArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateButton() 
    {
        if (isDel)
        {
            FindObjectOfType<BoardManager>().DelteAlphabet(); 
        }
        else if (isEnter)
        {
            FindObjectOfType<BoardManager>().ConfirmAnswer(); 
        }
        else
        {
            FindObjectOfType<BoardManager>().InsertAlphabet(buttonText[0]);  
        }
    }
}
