using ProcketZone2.Enemys;
using UnityEngine;

namespace ProcketZone2
{
    public class Game : MonoBehaviour
    {
        private static Game _instance;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private LevelManeger _levelManeger;
        [SerializeField] private ProcketZone2.Player.Player _player;

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else Destroy(gameObject);
        }
        private void Start()
        {
            _enemySpawner.Spawn();
            _enemySpawner.OnEnemyEnd.AddListener(WinGame);
            _player.OnDie.AddListener(LoseGame);
        }
        private void WinGame()
        {
            _levelManeger.ReloadLevel();
            _player.SaveParameters();
        }
        private void LoseGame()
        {
            _levelManeger.ReloadLevel();
        }
    }
}

