using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

using Assets.Utils;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeagueSelect : Singleton<LeagueSelect>
{
    private int closeAtFrame;
    private bool isShowing;
    public GameObject LeaguePanelCanvas;
    public GameObject LeaguePanelPrefab;
    public GraphicRaycaster Raycaster;
    public bool showPopUp;

    public bool WaitingToClose;

    public League SelectedLeague { get; set; }

    // Start is called before the first frame update
    public void Start()
    {
        LeaguePanelCanvas?.SetActive(false);
    }

    public void Awake()
    {
        enabled = false;
        if (enabled)
        {
            Raycaster = LeaguePanelCanvas?.GetComponent<GraphicRaycaster>();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (showPopUp && !isShowing)
        {
            isShowing = true;

            LeaguePanelCanvas.SetActive(true);
            PrepareCanvas();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            var pointerData = new PointerEventData(EventSystem.current);
            var results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            Raycaster.Raycast(pointerData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (var result in results)
            {
                var league = result.gameObject.GetComponent<League>();

                Debug.Log($"Hit {result.gameObject.name} {league?.LeagueName}");

                if (league != null)
                {
                    closeAtFrame = Time.frameCount + 15;
                    WaitingToClose = true;
                    SelectedLeague = Instantiate(league);
                }
            }
        }

        WaitToClose();
    }

    public void WaitToClose()
    {
        if (WaitingToClose && closeAtFrame <= Time.frameCount)
        {
            isShowing = false;
            showPopUp = false;
            LeaguePanelCanvas.SetActive(false);

            foreach (Transform prefab in LeaguePanelCanvas.transform.Find("Panel"))
            {
                Destroy(prefab.gameObject);
            }
        }
    }

    public void OnGUI() { }

    public void PrepareCanvas()
    {
        foreach (var i in Enumerable.Range(0, 3))
        {
            var prefab = Instantiate(LeaguePanelPrefab, new Vector3(0, 0, 0), Quaternion.identity,
                LeaguePanelCanvas.transform.Find("Panel"));

            var league = prefab.AddComponent<League>();

            foreach (var child in prefab.GetComponentsInChildren<Text>())
            {
                switch (child.name)
                {
                    case "Funding":
                        child.text = $"{League.GetDescriptionFor(nameof(League.Funding))}: {league.Funding}";

                        break;

                    case "LeagueName":
                        child.text = $"{league.LeagueName} {League.GetDescriptionFor(nameof(League.LeagueName))}";

                        break;

                    case "WeeklyGames":
                        child.text = $"{League.GetDescriptionFor(nameof(League.WeeklyGames))}: {league.WeeklyGames}";

                        break;

                    case "Size":
                        child.text = $"{League.GetDescriptionFor(nameof(League.Size))}: {league.Size}";

                        break;
                }
            }
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public int Size { get; set; } //todo wtf does this mean?
    }

    public class League : MonoBehaviour
    {
        private League() { }

        public List<Team> Teams { get; set; }
        [Description("League")] public string LeagueName { get; set; }
        [Description("Weekly Games")] public int WeeklyGames { get; set; }
        [Description("Weekly Funding")] public int Funding { get; set; }
        [Description("Team Count")] public int Size { get; set; }

        public static string GetDescriptionFor(string propertyName)
        {
            return typeof(League).GetProperties().First(p => p.Name == propertyName)
                .GetCustomAttribute<DescriptionAttribute>().Description;
        }

        public void Awake()
        {
            var size = Mathf.Clamp((int)(Random.value * 20) * 2, 10, 32);

            Teams = BaseballTeamNameGenerator.GetNames(size).Select(n => new Team { Name = n }).ToList();
            WeeklyGames = Mathf.Clamp(size / 2 + Random.Range(-3, 3), 5, 20);
            Funding = 100 * Random.Range(3, 10);
            Size = size;
            LeagueName = LeagueNameGenerator.GetNames(1).First();

            enabled = false;
        }
    }
}