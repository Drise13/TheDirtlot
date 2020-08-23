namespace Assets.Managers
{
    using UnityEngine;

    using Utils;

    public class RandomManager : Singleton<RandomManager>
    {
        public string Seed = "This is a seed";

        public void Awake()
        {
            Random.InitState(Seed.GetHashCode());
        }
    }
}