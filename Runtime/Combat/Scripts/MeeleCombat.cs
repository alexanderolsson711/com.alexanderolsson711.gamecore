using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.Combat
{
    public class MeeleCombat : BaseCharacterCombat
    {
        [SerializeField]
        private float attackPointRadius = 0.5f;

        protected override void DoAttack()
        {
            List<IHurtable> hurtables = Physics.OverlapSphere(transform.position + transform.forward * attackRange, attackPointRadius)
                                               .Select(c => c.GetComponent<IHurtable>())
                                               .Where(h => h != null).ToList();
            if (hurtables.Count >= 1)
            {
                hurtables.First().Hurt(attackDmg);
            }
        }
    }
}
