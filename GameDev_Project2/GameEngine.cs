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
        public bool MoveEnemy(Character C, Character.Movement m)
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
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Enemy);
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
            for (int i = 0; i == map.MapArray.Length-1; i++)
            {
                if (map.enemies[i].CheckDistanceToTarget(map.enemies[i], map.hero) == 1)
                {
                    map.enemies[i].Attack(map.enemies[0]);
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
                    Console.WriteLine("waa1");
                    MoveEnemy(map.enemies[i], Character.Movement.Up);

                    if (map.enemies[i].GetY() > map.hero.GetY())
                    {
                        Console.WriteLine("waa2");
                        MoveEnemy(map.enemies[i], Character.Movement.Left);
                    }

                    else if (map.enemies[i].GetY() < map.hero.GetY())
                    {
                        Console.WriteLine("waa3");
                        MoveEnemy(map.enemies[i], Character.Movement.Right);
                    }

                   else if (map.enemies[i].GetY() == map.hero.GetY())
                    {
                        Console.WriteLine("waa4");
                    }
                    
                }

                else if (map.enemies[i].GetX() < map.hero.GetX())
                {
                    Console.WriteLine("waa5");
                    MoveEnemy(map.enemies[i], Character.Movement.Down);

                    if (map.enemies[i].GetY() > map.hero.GetY())
                    {
                        Console.WriteLine("waa6");
                        MoveEnemy(map.enemies[i], Character.Movement.Left);
                    }

                    else if (map.enemies[i].GetY() < map.hero.GetY())
                    {
                        Console.WriteLine("waa7");
                        MoveEnemy(map.enemies[i], Character.Movement.Right);
                    }
                    else if (map.enemies[i].GetY() == map.hero.GetY())
                    {
                        Console.WriteLine("waa8");
                    }
                }

                else if (map.enemies[i].GetX() == map.hero.GetX())
                {
                    Console.WriteLine("waa9");
                    MoveEnemy(map.enemies[i], Character.Movement.NoMovement);
                    if (map.enemies[i].GetY() > map.hero.GetY())
                    {
                        Console.WriteLine("waa10");
                        MoveEnemy(map.enemies[i], Character.Movement.Left);
                    }

                    else if (map.enemies[i].GetY() < map.hero.GetY())
                    {
                        Console.WriteLine("waa11");
                        MoveEnemy(map.enemies[i], Character.Movement.Right);
                    }
                    else if (map.enemies[i].GetY() == map.hero.GetY())
                    {
                        Console.WriteLine("waa12");
                    }
                }

            }
            
            EnemyAttacks();
        }

        
    }
}
