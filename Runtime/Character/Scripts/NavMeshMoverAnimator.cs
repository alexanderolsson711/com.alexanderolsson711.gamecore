using UnityEngine;
using UnityEngine.AI;

namespace GameCore.Character
{
    public class NavMeshMovementAnimationHanlder : MonoBehaviour
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
                animator.SetMovementSpeed(agent.velocity.magnitude / normalizeSpeed);
            }
        }

        public void SetAnimator(ICharacterAnimator animator)
        {
            this.animator = animator;
        }
    }
}