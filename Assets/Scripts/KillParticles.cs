using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class KillParticles : MonoBehaviour, Bullet.IPrefabLifeTime
{
    public void EndLifeTime(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
        EndLifeTime(.4f);
    }

}
