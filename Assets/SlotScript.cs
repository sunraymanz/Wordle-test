using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlotScript : MonoBehaviour
{
    private TextMeshProUGUI textToken;
    public char letter;
    // Start is called before the first frame update
    void Start()
    {
        textToken = GetComponentInChildren<TextMeshProUGUI>();
        textToken.text ="";
    }

    // Update is called once per frame
    public void SetText(char str)
    {
        letter = str;
        textToken.text = str.ToString();
    }
    public char GetText()
    {
        return letter;
    }
}
