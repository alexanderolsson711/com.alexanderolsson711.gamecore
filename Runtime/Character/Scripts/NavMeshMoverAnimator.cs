using UnityEngine;
using UnityEngine.AI;

namespace GameCore.Character
{
    public class NavMeshMovementAnimationHandler : MonoBehaviour
    {
        private float normalizeSpeed;
        private NavMeshAgent agent;
        private ICharacterAnimator animator;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            normalizeSpeed = agent.speed;
        }

        private void Update()
        {
            if (animator != null)
            {
                animator.SetMovementSpeed(agent.velocity.magnitude);
            }
        }

        public void SetAnimator(ICharacterAnimator animator)
        {
            this.animator = animator;
        }
    }
}