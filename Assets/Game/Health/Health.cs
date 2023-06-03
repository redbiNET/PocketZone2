using ProcketZone2.UI;
using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Health :  IDamageble
{
    [SerializeField] private int _maxHP;

    private int _health;
    public int HP 
    { get
        {
            return _health;
        }
        private set 
        {
            _health = value;
            OnHealthChanged.Invoke(value);
        } 
    }
    public UnityEvent<int> OnHealthChanged = new UnityEvent<int>();
    public UnityEvent OnHealthOver = new UnityEvent();

    public void Init(IDamageGetter[] getters, HealthBar healthBar)
    {
        healthBar.SetMaxHealth(_maxHP);
        OnHealthChanged.AddListener(healthBar.ChangeValue);
        HP = _maxHP;
        foreach (IDamageGetter getter in getters)
        {
            getter.Subscribe(this);
        }
    }
    public void GetDamage(int damage)
    {
        if(damage >= 0)
        HP -= damage;
        if(HP <= 0)
        {
            OnHealthOver.Invoke();
        }
    }
}
