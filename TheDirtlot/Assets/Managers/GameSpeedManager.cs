namespace Assets.Managers
{
    using JetBrains.Annotations;

    using UnityEngine;

    using Utils;

    public class GameSpeedManager : Singleton<GameSpeedManager>
    {
        public enum GameSpeeds
        {
            Normal = 30,
            Fast = 15,
            Cheetah = 5
        }

        public bool UpdateStateThisFrame => ShouldProgressGameState();

        public GameSpeeds GameSpeed = GameSpeeds.Normal;

        [UsedImplicitly]
        public void Awake()
        {

        }

        [UsedImplicitly]
        public void Start()
        {
            Application.targetFrameRate = 60;
        }

        [UsedImplicitly]
        public void Update()
        {

        }

        private bool ShouldProgressGameState()
        {
            return Time.frameCount % GameSpeed.As<int>() == 0;
        }
    }
}