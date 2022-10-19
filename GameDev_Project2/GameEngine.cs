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
        
        public bool MovePlayer(Character.Movement c)
        {

            PlayerMoves = true;
            //Moves the player if able
            
            switch (c)
            {
                
                case Character.Movement.NoMovement:
                    PlayerMoves = false;
                    break;

                case Character.Movement.Up:

                    map.GetXY(map.hero.GetX(), map.hero.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    map.hero.SetY(map.hero.GetY() - 1);
                    break;

                case Character.Movement.Down:
                    map.GetXY(map.hero.GetX(), map.hero.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    map.hero.SetY(map.hero.GetY() + 1);
                    break;

                case Character.Movement.Left:
                    map.GetXY(map.hero.GetX(), map.hero.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    map.hero.SetX(map.hero.GetX() - 1);
                   
                    break;

                case Character.Movement.Right:
                    map.GetXY(map.hero.GetX(), map.hero.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                    map.hero.SetX(map.hero.GetX() + 1);
                    break;

                   
                default:
                    break;
            }
            //Fills the players new position by setting the tile type
            map.GetXY(map.hero.GetX(), map.hero.GetY()).SetCurrentTileType(Tile.TileType.Hero);
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
                else
                {

                }
            }
        }

        public void MoveEnemies(Character h)
        {
            Tile[] pTile = new Tile[map.enemies.Length - 1];
            for (int i = 0; i <= pTile.Length; i++)
            {
               
                if (map.enemies[i].GetY() < h.GetY())
                {
                    
                    map.enemies[i].SetY(map.enemies[i].GetY() + 1);
                    
                    if (map.enemies[i].GetX() < h.GetX())
                    {
                       
                        map.enemies[i].SetX(map.enemies[i].GetX() + 1);

                    }
                   else if (map.enemies[i].GetX() < h.GetX())
                    {
                       
                        map.enemies[i].SetX(map.enemies[i].GetX() - 1);
                    }
                }

                else if (map.enemies[i].GetY() > h.GetY())
                {
                  
                    map.enemies[i].SetY(map.enemies[i].GetY() - 1);

                    if (map.enemies[i].GetX() < h.GetX())
                    {
                      
                        map.enemies[i].SetX(map.enemies[i].GetX() + 1);
                    }
                    else if (map.enemies[i].GetX() < h.GetX())
                    {
                       
                        map.enemies[i].SetX(map.enemies[i].GetX() - 1);
                        
                    }
                }
                map.GetXY(map.enemies[i].GetX(), map.enemies[i].GetY()).SetCurrentTileType(Tile.TileType.Enemy);
            }
            
            EnemyAttacks();
        }
    }
}
