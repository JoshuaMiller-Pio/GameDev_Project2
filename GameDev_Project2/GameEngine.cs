using System;

namespace GameDev_Project2
{
    public class GameEngine
    {
        public Map map;
        private bool PlayerMoves;
     
        public GameEngine()
        {

            map = new Map(10, 9, 7);
            
        }

        //If a move is possible this moves the player object and changes the tile types of both the new and old positions

        public bool MovePlayer(Character C, Character.Movement m)
        {

            PlayerMoves = true;
            //Moves the player if able
            
            switch (m)
            {
                
                case Character.Movement.NoMovement:
                    PlayerMoves = false;
                    break;

                case Character.Movement.Up:

                    map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    C.SetY(C.GetY() - 1);
                    break;

                case Character.Movement.Down:
                    map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    C.SetY(C.GetY() + 1);
                    break;

                case Character.Movement.Left:
                    map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    C.SetX(C.GetX() - 1);
                   
                    break;

                case Character.Movement.Right:
                    map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    C.SetX(C.GetX() + 1);
                    break;

                   
                default:
                    break;
            }
            //Fills the players new position by setting the tile type
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Hero);
            return PlayerMoves;
        }

        public string ShowMap()
        {
            string DisplayMap = Convert.ToString(map.MapArray);
            return string.Format(DisplayMap);
        }



        //still in progress
        public void EnemyAttacks() 
        {
            for (int i = 0; i < map.MapArray.Length-1; i++)
            {
                if (map.enemies[0].CheckDistanceToTarget(map.enemies[0], map.hero) == 1)
                {
                    map.enemies[0].Attack(map.hero);
                }
          
            }
        }

        public void MoveEnemies(Character h)
        {
            Tile[] pTile = new Tile[map.enemies.Length - 1];
            for (int i = 0; i < map.enemies.Length; i++)
            {
                if (map.enemies[i].GetX() > map.hero.GetX())
                {
                    MovePlayer(map.enemies[i], Character.Movement.Up);
                }
                if (map.enemies[i].GetX() < map.hero.GetX())
                {
                    MovePlayer(map.enemies[i], Character.Movement.Down);
                }
                if (map.enemies[i].GetX() > map.hero.GetX())
                {
                    MovePlayer(map.enemies[i], Character.Movement.Left);
                }
                if (map.enemies[i].GetX() < map.hero.GetX())
                {
                    MovePlayer(map.enemies[i], Character.Movement.Right);
                }
            }
            
            EnemyAttacks();
        }

        
    }
}
