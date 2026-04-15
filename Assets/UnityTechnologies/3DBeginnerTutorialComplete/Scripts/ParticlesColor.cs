using UnityEngine;

public class ParticlesColor : MonoBehaviour
{
    public Gradient colorGradient;
    public Gradient triggerGradient;

    private Observer[] enemies;
    private bool trigger = false;
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        enemies = FindObjectsOfType<Observer>();

        SetGradient(colorGradient);
    }

    void Update()
    {
        foreach (Observer enemy in enemies)
        {
            if (enemy.enemyType == Observer.EnemyType.Ghost && enemy.isLookingAtPlayer)
            {
                if (!trigger)
                {
                    trigger = true;
                    SetGradient(triggerGradient);
                }
                return;
            }
        }

        if (trigger)
        {
            trigger = false;
            SetGradient(colorGradient);
        }
    }

    void SetGradient(Gradient gradientToUse)
    {
        var colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.enabled = true;
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradientToUse);
    }
}