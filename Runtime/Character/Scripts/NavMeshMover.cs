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


        public NavMeshMover(ICharacter character, NavMeshAgent agent, float speed)
        {
            this.agent = agent;
            agent.speed = speed;
            angularSpeed = speed * ANGULAR_SPEED_RATIO;
            agent.gameObject.AddComponent<NavMeshMovementAnimationHandler>().SetAnimator(character.GetCharacterAnimator());
        }

        public void MoveTo(Vector3 pos)
        {
            agent.angularSpeed = angularSpeed;
            agent.SetDestination(pos);
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

        public void TurnTowards(Vector3 point)
        {
            agent.transform.LookAt(point);
        }
    }
}