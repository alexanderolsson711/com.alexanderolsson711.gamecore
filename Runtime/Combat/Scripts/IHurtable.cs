using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Combat
{
    public interface IHurtable
    {
        void Hurt(int damage);
    }
}
