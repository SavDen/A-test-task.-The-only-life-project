using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyType", order = 52)]
public class EnemyType : ScriptableObject
{
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float turnSpeed { get; private set; }
    [field: SerializeField] public float health { get; private set; }
    [field: SerializeField] public float disAttack { get; private set; }
    [field: SerializeField] public float disView { get; private set; }
    [field: SerializeField] public Material skinMaterial { get; private set; }
}
