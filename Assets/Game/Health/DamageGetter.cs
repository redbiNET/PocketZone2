using UnityEngine;

public class DamageGetter : MonoBehaviour, IDamageble, IDamageGetter
{
    [SerializeField] private float _DamageMultiplayer = 1;
    private IDamageble _health;

    public void GetDamage(int damage)
    {
        _health.GetDamage((int)(damage * _DamageMultiplayer));
    }

    public void Subscribe(IDamageble damageble)
    {
        _health = damageble;
    }
}
public interface IDamageGetter
{
    public void Subscribe(IDamageble damageble);
}
