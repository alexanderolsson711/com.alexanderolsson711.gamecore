using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.Combat
{
    public class MeeleCombat : BaseCharacterCombat
    {
        [SerializeField]
        private AttackPoint attackPoint = null;

        protected override void DoAttack()
        {
            List<IHurtable> hurtables = attackPoint.GetHurtables();
            if (hurtables.Count >= 1)
            {
                hurtables.First().Hurt(attackDmg);
            }
        }
    }
}
