using UnityEngine;
using UnityEngine.AI;

namespace GameCore.Character
{
    public class NavMeshMover : ICharacterMover
    {
        private const float DROP_HEIGHT = 3f;
        private const float STEP_HEIGHT = 1f;
        private const float JUMP_DISTANCE = 3f;
        private const float SEARCH_STEP_SIZE = 0.1f;
        private const int ANGULAR_SPEED_RATIO = 40;

        private readonly NavMeshAgent agent;
        private readonly float angularSpeed;
        private readonly bool verticalForzen;

        private Vector3 currentDestination;

        public NavMeshMover(ICharacter character, NavMeshAgent agent, bool verticalForzen = false)
        {
            this.verticalForzen = verticalForzen;
            this.agent = agent;
            agent.speed = character.GetCharacterStats().MovementSpeed;
            angularSpeed = agent.speed * ANGULAR_SPEED_RATIO;
            agent.angularSpeed = angularSpeed;
            agent.gameObject.AddComponent<NavMeshMovementAnimationHandler>().SetAnimator(character.GetCharacterAnimator());
        }

        public Transform GetTransform()
        {
            return agent.transform;
        }

        public void MoveTo(Vector3 position)
        {
            if (position != currentDestination || !agent.hasPath)
            {
                currentDestination = position;
                agent.SetDestination(currentDestination);
            }
        }

        public void MoveTowards(Vector3 direction)
        {
            agent.angularSpeed = 0;
            for (float height = -DROP_HEIGHT; height <= STEP_HEIGHT; height+=SEARCH_STEP_SIZE)
            {
               for (float dist = 1; dist <= JUMP_DISTANCE; dist += SEARCH_STEP_SIZE) 
               {
                    Vector3 possibleDestination = agent.transform.position + dist * direction - height * Vector3.up;
                    if (NavMesh.SamplePosition(possibleDestination, out NavMeshHit hit, SEARCH_STEP_SIZE, NavMesh.AllAreas))
                    {
                        agent.SetDestination(hit.position);
                        return;
                    }
                }
            }
        }

        public void Stop()
        {
            agent.ResetPath();
        }

        public void TeleportTo(Vector3 position)
        {
            agent.Warp(position);
        }

        public void TurnTowards(Vector3 point)
        {
            if (verticalForzen)
            {
                point.y = agent.transform.position.y;
            }
            agent.transform.LookAt(point);
        }

        public void Rotate(Vector3 euler)
        {
            if (verticalForzen)
            {
                euler.x = 0;
                euler.z = 0;
            }
            agent.transform.Rotate(euler);
        }
    }
}