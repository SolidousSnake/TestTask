namespace _Project.MVP.Factory
{
    public sealed class FactoryModel
    {
        public FactoryModel(float cubeSpeed, float disappearDistance, float spawnDelay)
        {
            CubeSpeed = cubeSpeed;
            DisappearDistance = disappearDistance;
            SpawnDelay = spawnDelay;
        }

        public float CubeSpeed { get; set; }
        public float DisappearDistance { get; set; }
        public float SpawnDelay { get; set; }
    }
}
