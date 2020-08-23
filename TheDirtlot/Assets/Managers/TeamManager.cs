namespace Assets.Managers
{
    using JetBrains.Annotations;

    using UnityEngine;

    using Utils;

    public class TeamManager : Singleton<TeamManager>
    {
        private GameSpeedManager gameSpeedManager;
        private LeagueSelect leagueSelect;

        private bool ShouldPresentNewTeams()
        {
            return Random.value > 0.8;
        }

        public void Awake()
        {
            gameSpeedManager = GameSpeedManager.Instance;
            leagueSelect = LeagueSelect.Instance;
        }

        public void Update()
        {
            if (gameSpeedManager?.UpdateStateThisFrame ?? false)
            {
                ProgressState();
            }

            if (leagueSelect.SelectedLeague != null)
            {
                leagueSelect.showPopUp = false;
            }
        }

        public void ProgressState()
        {
            if (ShouldPresentNewTeams() && !leagueSelect.showPopUp)
            {
                leagueSelect.showPopUp = true;
            }
        }
    }
}