﻿using UnityEngine;

namespace Player_Controller
{
    /// <summary>
    /// To be change**
    /// Takes in the effects to be reproduce when the player is damaged
    /// </summary>
    public class DamageComponent : MonoBehaviour
    {
        // Reproduce the sound effects
        void SoundDamage(AudioClip damageSound, AudioSource player) => player.PlayOneShot(damageSound);
        
        // Reproduce the visual effects 
        void VfxDamage(ParticleSystem damageParticles) => damageParticles.Play();
    }
}