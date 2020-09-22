using System.Collections;
using UnityEngine;

namespace _Scripts.FG.Weapons
{
    public interface IWeapons
    {
        void Shoot(); // Shooting Enemy 
        void LaunchProjectile();
        GameObject GetWeaponUI(); // Getting Weapon UI To update Slot
    }
}