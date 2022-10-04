using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    public class Swamp_Creature : Enemy
    {
        public Swamp_Creature(int x, int y) : base(x, y, 10, 1, 1, "Swamp Creature")
        {
        }

        public override Movement ReturnMove(Movement move = Movement.NoMovement)
        {
            int EnemyDirection = random.Next(4);

            if (EnemyDirection == 0 && CharacterVision[X, Y - 1].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Up;
            }
            if (EnemyDirection == 1 && CharacterVision[X, Y + 1].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Down;
            }
            if (EnemyDirection == 2 && CharacterVision[X - 1, Y].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Left;
            }
            if (EnemyDirection == 3 && CharacterVision[X + 1, Y].GetCurrentTileType() == TileType.Empty)
            {
                return Movement.Right;
            }

            return Movement.NoMovement;
        }
    }
}
