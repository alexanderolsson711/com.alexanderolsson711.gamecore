using UnityEngine;

namespace GameCore.Character
{
    [CreateAssetMenu(fileName = "Stats", menuName = "GameCore/Character/Stats")]
    public class CharacterStats : ScriptableObject
    { 
        public int StartHealth => startHealth;
        public float MovementSpeed => movementSpeed;
        public int AttackDamage => attackDamage;
        public float AttackSpeed => attackSpeed;
        public float AttackRange => attackRange;

        [SerializeField]
        private int startHealth = 3;

        [SerializeField]
        private float movementSpeed = 3;

        [SerializeField]
        private int attackDamage = 1;

        [SerializeField]
        private float attackSpeed = 1;

        [SerializeField]
        private float attackRange = 1.1f;
    }
}
