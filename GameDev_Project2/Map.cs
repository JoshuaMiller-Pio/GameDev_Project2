using System;
using static GameDev_Project2.Tile;

namespace GameDev_Project2
{
    public class Map
    {
        public Enemy[] enemies;
        public Hero hero;

        private int MapWidth;
        private int MapHeight;
        private Random randomGenerator;

        public Tile[,] MapArray;

        public int GetMapWidth()
        {
            return MapWidth;
        }
        public int GetMapHeight()
        {
            return MapHeight;
        }

        //Constructs the map, set its various statistics, creates the hero object through the Create() and does the same for all enemies by runing the Create() through a for loop as long as the enemies array
        public Map(int randomWidthMax, int randomHeightMax)
        {
            randomGenerator = new Random();
            MapWidth = randomGenerator.Next(5, randomWidthMax);
            MapHeight = randomGenerator.Next(5, randomHeightMax);


            MapArray = new Tile[MapWidth, MapHeight];

            //Creates Obstacle objects around the borders of the map
            for (int x = 0; x < MapWidth; x++)
            {
                MapArray[x, 0] = new Obstacle(x, 0);
                MapArray[x, MapHeight - 1] = new Obstacle(x, MapHeight - 1);
            }
            for (int y = 0; y < MapHeight; y++)
            {
                MapArray[0, y] = new Obstacle(0, y);
                MapArray[MapWidth - 1, y] = new Obstacle(MapWidth - 1, y);
            }

            //Creates Empty_Tile objects throughout the array
            for (int x = 1; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    MapArray[x, y] = new Empty_Tile(x, y);
                }
            }

            //Calls the create function and tells it to create an enemy by passing through the enemy TileType, this is done through a for loop to create as many enemies as the enemies array requires
            enemies = new Enemy[randomGenerator.Next(1, 5)];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy)Create(Tile.TileType.Enemy);
            }

            ////Calls the create function and tells it to create a hero by passing through the Hero TileType
            hero = (Hero)Create(Tile.TileType.Hero);
            //UpdateVision(hero, hero.ReturnMove(Character.Movement.Up));

        }

        //Returns a tile in the map array at position XY
        internal Tile GetXY(int X, int Y)
        {
            return MapArray[Y, X];
        }

        public Tile UpdateVision(Character h, Character.Movement move)
        {
            switch (move)
            {
                case Character.Movement.NoMovement:
                    return h;
                case Character.Movement.Up:
                    Tile n = MapArray[h.GetX(), h.GetY() - 1];
                    n.SetY(h.GetY() - 1);
                    n.SetX(h.GetX());
                    return n;
                case Character.Movement.Down:
                    Tile s = MapArray[h.GetX(), h.GetY() + 1];
                    s.SetY(h.GetY() + 1);
                    s.SetX(h.GetX());
                    return s;
                case Character.Movement.Left:
                    Tile w = MapArray[h.GetX() - 1, h.GetY()];
                    w.SetX(h.GetX() - 1);
                    w.SetY(h.GetY());
                    return w;
                case Character.Movement.Right:
                    Tile e = MapArray[h.GetX() + 1, h.GetY()];
                    e.SetX(h.GetX() + 1);
                    e.SetY(h.GetY());
                    return e;
                default:
                    return h;
            }
            //updates vision for the character calling the UpdateVision()   
        }

        //Used to create objects of the various class and populate the map
        private Tile Create(Tile.TileType type)
        {
            // Gets the X and Y values for the current Tile
            int X = randomGenerator.Next(MapWidth);
            int Y = randomGenerator.Next(MapHeight);
            //If the current TileType is anything other than empty it rerolls X and Y values
            while (MapArray[X, Y].GetCurrentTileType() != Tile.TileType.Empty)
            {
                X = randomGenerator.Next(MapWidth);
                Y = randomGenerator.Next(MapHeight);
            }

            switch (type)
            {
                case TileType.Hero:
                    MapArray[X, Y] = new Hero(X, Y, "unset hero name");
                    break;
                case TileType.Enemy:
                    MapArray[X, Y] = new Swamp_Creature(X, Y); //create an if else with random chance to choose different enemies
                    break;
                case TileType.Gold:
                    break;
                case TileType.Weapon:
                    break;
            }

            return MapArray[X, Y];
        }
    }
}
