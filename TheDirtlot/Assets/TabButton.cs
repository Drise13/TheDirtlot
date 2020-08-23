using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Image BackgroundImage;
    public TabController TabController;

    public TabPanel TabPanel;

    public bool IsPrimary;

    public void OnPointerClick(PointerEventData eventData)
    {
        TabController.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TabController.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TabController.OnTabExit(this);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        BackgroundImage = GetComponent<Image>();
        TabController.Subscribe(this);
    }

    // Update is called once per frame
    private void Update() { }
}