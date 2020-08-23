namespace Assets.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;
    using UnityEngine.UI;

    public class ToolsFactory : Singleton<ToolsFactory>
    {
        [Serializable]
        public class ToolResource
        {
            public ToolType ToolType;
            public Sprite Image;
        }

        public List<ToolResource> ResourceList;

        public Dictionary<ToolType, Sprite> ResourceDictionary;

        public void Awake()
        {
            ResourceDictionary = ResourceList.ToDictionary(i => i.ToolType, i => i.Image);
        }

        public void Start()
        {
            enabled = false;
        }

        public GameObject GetTool(ToolType type, GameObject prefab, Transform owner)
        {
            var instance = Instantiate(prefab, owner);
            var tool = instance.GetComponent<Tool>();

            tool.ToolType = type;
            tool.ToolImage.sprite = ResourceDictionary[type];

            return instance;
        }
    }

    public enum ToolType
    {
        Dirt,
        Grass,
        BallPark,
        Bulldozer,
    }
}