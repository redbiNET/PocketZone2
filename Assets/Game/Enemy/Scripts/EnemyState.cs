using UnityEngine;

namespace ProcketZone2.Enemys
{
    public abstract class EnemyState
    {
        protected Transform transform;
        protected Transform center;
        protected Enemy stateMachine;

        public void Init(Enemy stateMachine, Transform transform, Transform center)
        {
            this.stateMachine = stateMachine;
            this.transform = transform;
            this.center = center;
            Start();
        }
        protected virtual void Start() {}
        public abstract void Enable();
        public abstract void Disable();
        public abstract void Update();

    }
}