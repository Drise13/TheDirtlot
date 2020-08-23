using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Tile : MonoBehaviour
{
    private Image backgroundImage;
    public int TileSize;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
