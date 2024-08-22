using UnityEngine;
using UnityEngine.AI;
using Lean.Pool;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private EnemyType enemyType;

    [SerializeField][Min(1)] private float health;
    [SerializeField][Min(1.5f)] private float disAttack;
    [SerializeField] private float disView;

    [SerializeField] private AnimController _animController;

    [SerializeField] private GameObject _weapon;
    [SerializeField] private ParticleSystem _bloodParticle;
    [SerializeField] private SkinnedMeshRenderer skinnedMesh;

    private Transform _playerTarget;
    private NavMeshAgent _navMeshAgent;
    private float _damageWeapon;

    private void OnEnable()
    {
        CointerKill.GameOver += Dead;
    }

    private void OnDisable()
    {
        CointerKill.GameOver -= Dead;
    }

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _damageWeapon = _weapon.GetComponent<Weapon>().damage;

        if(FindAnyObjectByType<CharacterController>())
        _playerTarget = FindAnyObjectByType<CharacterController>().transform;
    }

    public void DownloadData()
    {
        _navMeshAgent.speed = enemyType.moveSpeed;
        _navMeshAgent.angularSpeed = enemyType.turnSpeed;
        health = enemyType.health;
        disAttack = enemyType.disAttack;
        disView = enemyType.disView;
        skinnedMesh.materials[0] = enemyType.skinMaterial;
    }

    void Update()
    {
        if (_playerTarget != null)
        {
            var distance = Vector3.Distance(transform.position, _playerTarget.position);

            if (distance <= disAttack)
            {
                _animController.Move(false);
                _animController.Attack(true);
            }

            else if (distance <= disView)
            {
                _navMeshAgent.SetDestination(_playerTarget.position);
                _animController.Move(true);
                _animController.Attack(false);

            }

            else
            {
                _animController.Move(false);
                _animController.Attack(false);
            }
        }

        else
        {
            _animController.Move(false);
            _animController.Attack(false);
        }
    }

    public void GetDamage(float damage)
    {
        _bloodParticle.Play();

        if (health > 0)
        {
            health -= damage;
        }

        if (health <= 0) Dead();
    }

    public void TakeHit()
    {
        var hits = Physics.OverlapSphere(_weapon.transform.position, 1f);

        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent(out IPlayer player))
            {
                player.GetDamage(_damageWeapon);
            }
        }
    }

    public void StopAgent(int state)
    {
        if (state == 0) _navMeshAgent.isStopped = true;
        else _navMeshAgent.isStopped = false;
    }


    private void Dead()
    {
        _animController.Dead();
        LeanPool.Despawn(gameObject, 3f);
    }

    public void AddCountKill()
    {
        CointerKill.CountKill++;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, disView);
    }
#endif
}
