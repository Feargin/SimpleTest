namespace SimpleTest
{
    internal sealed class SpawnQubes : Spawner
    {
        private void Start()
        {
            //Test start spawner
            StartSpawner();
        }

        protected override void Configuration(Entity ent)
        {
            ent.Speed = speed;
            ent.Distance = distance;
        }
    }
}