using System;

namespace GameDev_Project2
{
    public abstract class Enemy : Character
    {
        protected Random random = new Random();
        public string EnemyInfo, EnemyName;

        //Constructor for Enemy
        public Enemy(int x, int y, double MaxHP, double Damage, double Range, string name, int symbol, TileType tiletype) : base(x, y, tiletype, symbol, MaxHP, Damage, Range, 0)
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
            return String.Format("Enemy Info:\n{0} at position: [{1},{2}] \nHP: {3} \nDamage: {4}\nGold Held: {5}", EnemyName, GetX() + 1, GetY() + 1, GetHP(), this.Damage, GetHeldGold());
        }

        public  string ToSaveString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5}", EnemyName, GetX() + 1, GetY() + 1, GetHP(), this.Damage, GetHeldGold());
        }
    }
}
