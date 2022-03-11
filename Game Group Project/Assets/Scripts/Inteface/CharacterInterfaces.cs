using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage<T>
{
    void TakeDamage(T damageAmount);
}

public interface IHeal<T>
{
    void HealCharacter(T healAmount);
}

public interface IKill
{
    void KillCharacter();
}
