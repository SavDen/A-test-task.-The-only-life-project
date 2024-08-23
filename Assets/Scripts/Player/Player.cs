using UnityEngine;

[RequireComponent(
    typeof(CharacterController)
    )]

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private float health;

    [SerializeField] private Character _character;
    [SerializeField] private AnimController _animController;
    [SerializeField] private ViewPlayer _viewPlayer;
    [SerializeField] private AudioSystem _audioSystem;

    [SerializeField] private GameObject _weapon;
    [SerializeField] private ParticleSystem _bloodFX;

    private PlayerInput _inputPlayer;
    private float _maxHealth;
    private float _yEuler;
    private float _damageWeapon;

    private void Awake()
    {
        _inputPlayer = new PlayerInput();
        _inputPlayer.Enable();

        _viewPlayer.StartUpdateUI(health);
        _audioSystem.Instalize();

        _maxHealth = health;

        _character.controller = GetComponent<CharacterController>();
        _damageWeapon = _weapon.GetComponent<Weapon>().damage;
    }

    void Update()
    {
        _character.Move(ReadInput());
        _character.Turn(ReadInput().z, transform);

        _animController.Move(ReadInput() != Vector3.zero);

        AudioMove(ReadInput() == Vector3.zero);
    }
   
    private Vector3 ReadInput()
    {
        var inputDiretion = _inputPlayer.Player.JoyStick.ReadValue<Vector3>();

        var direction = new Vector3(inputDiretion.x, 0, inputDiretion.z).normalized;

        return direction;
    }

    public void AnimAttack()
    {
        _animController.Attack();
    }

    private void AudioMove(bool mute)
    {
        _audioSystem.AudioDictinory["Move"].mute = mute;
    }

    public void PlayAttackSound()
    {
        _audioSystem.AudioDictinory["Attack"].Play();
    }

    public void TakeHit()
    {
        var hits = Physics.OverlapSphere(_weapon.transform.position, 0.3f);

        foreach(var hit in hits)
        {
            if (hit.transform.TryGetComponent(out IEnemy enemy))
            {
                enemy.GetDamage(_damageWeapon);
            }
        }
    }

    public void GetDamage(float damage)
    {
        _bloodFX.Play();
        _audioSystem.AudioDictinory["Damage"].Play();

        if (health > 0)
        {
            health -= damage;
            _viewPlayer.UpdateUI(health);
        }

        if (health <= 0) Dead();
    }

    public void GetHeals(float bonusHealth)
    {
        if (health + bonusHealth > _maxHealth) health = _maxHealth;

        else  health += bonusHealth;

        _viewPlayer.UpdateUI(health);
        _audioSystem.AudioDictinory["HP"].Play();
    }

    private void Dead()
    {
        _viewPlayer.ShowGameOver();
        _animController.Dead();
        _audioSystem.AudioDictinory["Dead"].Play();

        Destroy(gameObject, 3f);
    }

}
