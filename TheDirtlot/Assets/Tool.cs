using System.Collections;
using System.Collections.Generic;

using Assets.Managers;
using Assets.Utils;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Tool : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Image ToolImage;

    public Image ToolBorder;

    public Sprite ActiveSprite;
    public Sprite HoverSprite;
    public Sprite IdleSprite;

    public ToolType ToolType;

    public bool CurrentlySelected;
    // Start is called before the first frame update
    void Awake()
    {
        Reset();
    }

    private void Reset()
    {
        CurrentlySelected = false;
        ToolBorder.sprite = IdleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!CurrentlySelected)
        {
            ToolBorder.sprite = HoverSprite;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToolManager.Instance.SelectedTool?.Reset();
        ToolManager.Instance.SelectedTool = this;
        CurrentlySelected = true;
        ToolBorder.sprite = ActiveSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!CurrentlySelected)
        {
            ToolBorder.sprite = IdleSprite;
        }
    }
}
