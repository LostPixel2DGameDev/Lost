using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UITileCounter : MonoBehaviour
{
    public static UITileCounter instance;
    public TextMeshProUGUI TileCount;
    int Count;

    private void Awake() 
    {
        instance = this;
    }
    
    void Start()
    {
        Count = 0;
        TileCount.text = "Step Count: " + Count;
    }

    public void AddStep() 
    {
        Count++;
        TileCount.text = "Step Count: " + Count;
    }
    
}
