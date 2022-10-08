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
        
        //THIS DOES NOT WORK YET
        public bool MovePlayer(Hero h)
        {
            //Empties the players current tile
            map.GetXY(h.GetX(), h.GetY()).SetCurrentTileType(Tile.TileType.Empty);
            PlayerMoves = true;
            //Moves the player if able
            switch (h.ReturnMove(h.GetMove()))
            {
                case Character.Movement.NoMovement:
                    PlayerMoves = false;
                    break;
                case Character.Movement.Up:
                    h.SetY(h.GetY() - 1);
                    break;
                case Character.Movement.Down:
                    h.SetY(h.GetY() + 1);
                    break;
                case Character.Movement.Left:
                    h.SetX(h.GetX() - 1);
                    break;
                case Character.Movement.Right:
                    //h.SetX(h.GetX() + 1);
                    h.Move(Character.Movement.Right);
                    break;

                   
                default:
                    break;
            }
            //Fills the players new position by setting the tile type
            map.GetXY(h.GetX(), h.GetY()).SetCurrentTileType(Tile.TileType.Hero);
            return PlayerMoves;
        }

        public string ShowMap()
        {
            string DisplayMap = Convert.ToString(map.MapArray);
            return string.Format(DisplayMap);
        }
    }
}
