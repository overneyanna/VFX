using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleChange : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    ParticleSystem.ColorOverLifetimeModule colorModule;

    Gradient gradientMin;
    Gradient gradientMax;

    void Start()
    {
        
        ps = GetComponent<ParticleSystem>();
        colorModule = ps.colorOverLifetime;

        
        float alpha1 = 1.0f;
         gradientMin = new Gradient();
         gradientMin.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha1, 0.0f), new GradientAlphaKey(alpha1, 1.0f) }
        );

       
        float alpha2 = 0.0f;
           gradientMax = new Gradient();
           gradientMax.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha2, 0.0f), new GradientAlphaKey(alpha2, 1.0f) }
        );

        
        colorModule.color = new ParticleSystem.MinMaxGradient( gradientMin, gradientMax);

        
        Invoke("ModifyGradient", 2.0f);
    }

    void ModifyGradient()
    {
        
        float alpha = 0.5f;
        gradientMin.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );

       
        colorModule.color = new ParticleSystem.MinMaxGradient( gradientMin ,gradientMax);
    }
}
