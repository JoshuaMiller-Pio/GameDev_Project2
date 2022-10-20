using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    public class Hero : Character
    {
        public string HeroName;

        public Hero(int x, int y, string HeroName) : base(x, y, TileType.Hero, 0, 10, 2, 1, 1)
        {
            this.HeroName = HeroName;
        }

        //Overrides the ReturnMove() in character and returns an apropriate direction if a move is possible or NoMovement if it is not
        public override Movement ReturnMove(Movement move)
        {
            if (move == Movement.Up && CharacterVision[X, Y - 1].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Up;
            }
            if (move == Movement.Down && CharacterVision[X, Y + 1].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Down;
            }
            if (move == Movement.Left && CharacterVision[X - 1, Y].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Left;
            }
            if (move == Movement.Right && CharacterVision[X + 1, Y].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Right;
            }

            return Movement.NoMovement;
        }

        public override string ToString()
        {
            return String.Format("Player Stats:\n{0}\nHP: {1}/{2}\nDamage: {3}\nPosition: [{4},{5}]\nGold: {6}", HeroName, GetHP(), this.MaxHP, GetDamage(), GetX() + 1, GetY() + 1, GetHeldGold());
        }
    }
}
