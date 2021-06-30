using UnityEngine;

namespace GameCore.AI
{
    public static class PriorityHelper
    {
        public static float DistancePriority(Vector3 position1, Vector3 position2, float priorityFactor = 1)
        {
            return priorityFactor / Vector3.Distance(position1, position2);
        }

        public static float DistancePriority(Transform transform1, Transform transform2, float priorityFactor = 1)
        {
            return transform1 && transform2 ? DistancePriority(transform1.position, transform2.position, priorityFactor) : 0;
        }
        
        public static float DistancePriority(Transform transform, Vector3 position, float priorityFactor = 1)
        {
            return transform ? DistancePriority(transform.position, position, priorityFactor) : 0;
        }
    }
}
