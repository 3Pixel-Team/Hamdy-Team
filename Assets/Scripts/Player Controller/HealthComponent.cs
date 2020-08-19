﻿using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Thulk Code, 
/// </summary>
class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hpRegeneratedPerSecond;
    [SerializeField] private float HealthPackRate;
    public static float HealthPackHpToAdd = 0;
    public Health _health;
    private void Start()
    {
        _health = new Health(maxHp, maxHp);
        StartCoroutine(RegenHealth());
    }
    
    private IEnumerator RegenHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (_health.IsDepleted) yield break;
            if (HealthPackHpToAdd > 0){
                if (HealthPackHpToAdd > HealthPackRate){
                    HealthPackHpToAdd -= HealthPackRate;
                    _health = _health.Regenerate(HealthPackRate); 
                } else {
                    _health = _health.Regenerate(HealthPackHpToAdd);
                    HealthPackHpToAdd = 0;
                }
            }
            _health = _health.Regenerate(hpRegeneratedPerSecond);
        }
    }
}

public readonly struct Health
{
    public readonly float Current;
    public readonly float Max;
    public bool IsDepleted => Current <= 0f;
    public Health(float current, float max)
    {
        Current = Math.Max(0, Math.Min(current, max)); // Can also be writtend as Math.Clamp(current, 0, max);
        Max = max;
    }
    public Health DamagedBy(float damage) => new Health(Current - damage, Max);
    public Health Regenerate(float regen) => new Health(Current + regen, Max);
}