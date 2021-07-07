using UnityEngine;

namespace GameCore.Combat
{
    public class RangeCombat : BaseCharacterCombat
    {
        [SerializeField]
        private Transform firePoint = null;

        protected override void DoAttack()
        {
            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, attackRange))
            {
                if (hit.collider.TryGetComponent(out IHurtable hurtable))
                {
                    hurtable.Hurt(attackDmg);
                }
            }
        }
    }
}
