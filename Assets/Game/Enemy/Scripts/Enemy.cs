using ProcketZone2.Player.Items;
using ProcketZone2.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2.Enemys
{
    public class Enemy : Entity
    {
        [SerializeField] private Transform _center;
        public Transform Center => _center;
        [SerializeField] private Health _health;
        [SerializeField] private Vector2 _healthBarOffset;

        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ItemSpawner _spawner;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private IdleEnemyState _idleState;
        [SerializeField] private FollowEnemyState _followState;
        [SerializeField] private HitEnemyState _hitState;
        public EnemyState IdleState { get { return _idleState; } }
        public EnemyState FollowState { get { return _followState; } }
        public EnemyState HitState { get { return _hitState; } }

        [SerializeField] private EnemyState _currentState;
        [SerializeField] private LayerMask _playerMask;
        public UnityEvent OnDie = new UnityEvent();
        public EnemyAnimation Animation => _animation;
        public LayerMask PlayerMask => _playerMask;

        private void Awake()
        {
            InitStates();
            ChangeState(IdleState);
        }
        private void Start()
        {
            _healthBar = UIEntity.Instantiate(_healthBar);
            _healthBar.Init(transform, _healthBarOffset);
            _health.Init(GetComponentsInChildren<IDamageGetter>(), _healthBar);
            _health.OnHealthOver.AddListener(Die);
        }
        private void Update()
        {
            _currentState.Update();
        }
        private void InitStates()
        {
            _idleState.Init(this, transform, _center);
            _followState.Init(this, transform, _center);
            _hitState.Init(this, transform, _center);
        }
        public void ChangeState(EnemyState state)
        {
            if(_currentState != null) _currentState.Disable();
            _currentState = state;
            _currentState.Enable();
        }
        private void Die()
        {
            OnDie.Invoke();
            _spawner.SpawnRandomItem(transform.position);
            Destroy(this);
            Destroy(_healthBar.gameObject);
        }
    }
}

