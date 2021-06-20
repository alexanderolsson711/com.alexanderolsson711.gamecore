using System.Linq;
using UnityEngine;

namespace GameCore.Combat
{
    public class MeeleCombat : BaseCharacterCombat
    {
        [SerializeField]
        private HurtableColliderContainer attackPoint = null;

        protected override void DoAttack()
        {
            if (attackPoint.HurtablesInside.Count >= 1)
            {
                attackPoint.HurtablesInside.First().Hurt(attackDmg);
            }
        }
    }
}
