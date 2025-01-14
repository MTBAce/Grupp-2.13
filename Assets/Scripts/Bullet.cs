using UnityEngine;

public class Bullet : MonoBehaviour, Bullet.IPrefabLifeTime
{
    public void EndLifeTime(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
        EndLifeTime(1.3f);
    }
    public interface IPrefabLifeTime
    {
        void EndLifeTime(float lifeTime); //Kills the bullet after 1.3s
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
