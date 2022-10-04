using System;

namespace GameDev_Project2
{
    public abstract class Enemy : Character
    {
        protected Random random = new Random();
        public string EnemyInfo, EnemyName;

        //Constructor for Enemy
        public Enemy(int x, int y, double MaxHP, double Damage, double Range, string name) : base(x, y, TileType.Enemy, 1, MaxHP, Damage, Range)
        {
            this.EnemyName = name;
            this.EnemyInfo = "Unset enemy info";
        }

        //might need to add
        public override Movement ReturnMove(Movement move = Movement.NoMovement)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return String.Format("Enemy Info:\n{0} at [{1},{2}] ({3})", EnemyName, this.X + 1, this.Y + 1, this.Damage);
        }
    }
}
