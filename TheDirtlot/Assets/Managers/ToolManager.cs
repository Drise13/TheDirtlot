namespace Assets.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    using Utils;

    public class ToolManager : Singleton<ToolManager>
    {
        public GameObject ToolPrefab;
        public GameObject ContentHolder;

        public List<Tool> Tools = new List<Tool>();

        public Tool SelectedTool;

        public void Awake()
        {
            foreach (var value in Enum.GetValues(typeof(ToolType)).Cast<ToolType>())
            {
                Tools.Add(ToolsFactory.Instance.GetTool(value, ToolPrefab, ContentHolder.transform).GetComponent<Tool>());
            }
        }

        // Start is called before the first frame update
        public void Start()
        {

        }

        // Update is called once per frame
        public void Update() { }
    }
}