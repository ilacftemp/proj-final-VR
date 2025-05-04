using UnityEngine;

public class OilPour : MonoBehaviour
{
    public ParticleSystem oilParticles;
    public float tiltThreshold = 60f; // Ângulo de inclinação em graus

    void Update()
    {
        // Verifica o ângulo da garrafa
        float tilt = Vector3.Angle(transform.up, Vector3.up);

        if (tilt > tiltThreshold)
        {
            if (!oilParticles.isPlaying)
                oilParticles.Play();
        }
        else
        {
            if (oilParticles.isPlaying)
                oilParticles.Stop();
        }
    }
}
