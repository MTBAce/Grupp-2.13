using UnityEngine;

public class DamageParticleKill : MonoBehaviour, Bullet.IPrefabLifeTime
{
    public void EndLifeTime(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }

    void Start()
    {
        EndLifeTime(0.8f); //Kills the particles
    }
}
