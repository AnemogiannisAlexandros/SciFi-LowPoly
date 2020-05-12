using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IDamagable
    {
        int Health { get; }
        void TakeDamage();
    }
}
    