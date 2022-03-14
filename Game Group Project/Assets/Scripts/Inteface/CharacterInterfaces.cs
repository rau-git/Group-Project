using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage<in T>
{
    void TakeDamage(T damageAmount);
}

public interface IHeal<in T>
{
    void HealCharacter(T healAmount);
}

public interface IKill
{
    void KillCharacter();
}
