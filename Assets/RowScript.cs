using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    [SerializeField] public SlotScript[] slots;
    // Start is called before the first frame update
    private void Awake()
    {
        slots = GetComponentsInChildren<SlotScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
