using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class TabController : MonoBehaviour
{
    public Sprite ActiveSprite;
    public Sprite HoverSprite;
    public Sprite IdleSprite;

    public TabButton SelectedButton;

    public List<TabButton> TabButtons = new List<TabButton>();

    public void Subscribe(TabButton tabButton)
    {
        TabButtons.Add(tabButton);
    }

    public void OnTabEnter(TabButton tabButton)
    {
        ResetTabs();

        if (tabButton != SelectedButton)
        {
            tabButton.BackgroundImage.sprite = HoverSprite;
        }
    }

    public void Start()
    {
        OnTabSelected(TabButtons.FirstOrDefault(b => b.IsPrimary));
        ResetTabs();
    }

    public void OnTabExit(TabButton tabButton)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton tabButton)
    {
        tabButton.BackgroundImage.sprite = ActiveSprite;

        SelectedButton?.TabPanel.Panel.SetActive(false);
        tabButton.TabPanel.Panel.SetActive(true);

        SelectedButton = tabButton;
        ResetTabs();
    }

    public void ResetTabs()
    {
        foreach (var button in TabButtons.Where(b => b != SelectedButton))
        {
            button.BackgroundImage.sprite = IdleSprite;
        }
    }
}