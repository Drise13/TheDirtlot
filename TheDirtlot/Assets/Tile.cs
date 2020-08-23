using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Tile : MonoBehaviour
{
    private Image backgroundImage;
    public int TileSize;

    public Tool CurrentTool;

    void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage.sprite = CurrentTool?.ToolImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImage.sprite = CurrentTool?.ToolImage.sprite;
    }
}
