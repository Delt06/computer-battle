using System;

namespace Battle
{
    public interface IHittable
    {
        event Action ReceivedDamage;
        void ReceiveDamage(float damage);
        event Action Died;
    }
}