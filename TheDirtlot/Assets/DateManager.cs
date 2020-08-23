namespace Assets
{
    using System;

    using Managers;

    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class DateManager : MonoBehaviour
    {
        private Text dateInfo;
        public DateTime DateTime;
        private GameSpeedManager gameSpeedManager;

        // Start is called before the first frame update
        private void Start()
        {
            gameSpeedManager = GameSpeedManager.Instance;
            dateInfo = GetComponent<Text>();
            DateTime = DateTime.Parse("Jan 1, 1970");
        }

        // Update is called once per frame
        private void Update()
        {
            if (gameSpeedManager.UpdateStateThisFrame)
            {
                DateTime = DateTime.AddHours(1);
                dateInfo.text = DateTime.ToString("ddd MMM d, yyyy HH:00");
            }
        }
    }
}