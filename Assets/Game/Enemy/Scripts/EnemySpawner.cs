using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private List<Enemy> _spawnedEnemies;
        [SerializeField] private int _count;
        [SerializeField] private Vector2 _spawnField;
        [SerializeField] private float _obstacleCheckRadius;
        [SerializeField] private LayerMask _obstacleMask;

        public UnityEvent OnEnemyEnd = new UnityEvent();
        public void Spawn()
        {
            _spawnedEnemies = new List<Enemy>();
            for (int i = 0; i < _count; i++)
            {
                Enemy enemy = _enemies[Random.Range(0, _enemies.Length)];
                int repetitons = 0;
                while(repetitons < 1000)
                {
                    Vector2 position = new Vector2(Random.Range(-_spawnField.x, _spawnField.x), Random.Range(-_spawnField.y, _spawnField.y));
                    repetitons++;
                    position += new Vector2(transform.position.x, transform.position.y);
                    Collider2D collider = Physics2D.OverlapCircle(position, _obstacleCheckRadius, _obstacleMask);
                    if(collider == null)
                    {
                        Enemy spawnedEnemy = Entity.Instantiate(enemy);
                        _spawnedEnemies.Add(spawnedEnemy);
                        spawnedEnemy.OnDie.AddListener(() => DeleteEnemy(spawnedEnemy));
                        _spawnedEnemies[i].transform.position = position;
                        break;
                    }
                }
            }
        }
        private void DeleteEnemy(Enemy enemy)
        {
            _spawnedEnemies.Remove(enemy);
            if(_spawnedEnemies.Count == 0)
            {
                OnEnemyEnd.Invoke();
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, _spawnField*2);
        }
    }
}

