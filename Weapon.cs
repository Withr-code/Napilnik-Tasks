using System;

class Weapon
{
    public int Damage { get; private set; }
    public int Bullets { get; private set; }
    public int BulletsPerShoot { get; private set; }

    public bool CanFire { get; private set; } => Bullets >= BulletsPerShoot;

    public void TryFire(Health player)
    {
        if (CanFire)
        {
            player.TryTakeDamage(Damage);
            Bullets -= _bulletsPerShoot;
        }
        else
        {
            throw new ArgumentOutOfRangeException(Bullets);
        }
    }
}

class Health
{
    public int Value { get; private set; }
    public bool IsDead { get; private set; } => Value < 0

    public void TryTakeDamage(int damage)
    {
        if (IsDead)
            return;
        else if (damage < 0)
            throw new ArgumentOutOfRangeException(damage);
        else if (damage > Value)
            Die();
        else
            Value -= damage;
    }

    private void Die()
    {
        Isdead = true;
    }
}

class Player
{
    public Health Health { get; private set} = new Health();
}

class Bot
{
    public Weapon Weapon { get; private set; } = new Weapon();

    public void OnSeePlayer(Health player)
    {
        Weapon.TryFire(player);
    }
}