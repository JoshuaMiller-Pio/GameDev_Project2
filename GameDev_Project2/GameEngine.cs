using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace GameDev_Project2
{
    public class GameEngine
    {
        public Map map;
        private bool PlayerMoves, Enemymoves;
        Utility myUtility = new Utility();
        public GameEngine()
        {

            map = new Map(10, 9, 7);


        }
        public string ShowMap()
        {
            string DisplayMap = Convert.ToString(map.MapArray);
            return string.Format(DisplayMap);
        }

        //If a move is possible this moves the player object and changes the tile types of both the new and old positions
        public bool MovePlayer(Character C, Character.Movement m)
        {

            PlayerMoves = true;
            //Moves the player if able to

            switch (m)
            {

                case Character.Movement.NoMovement:
                    PlayerMoves = false;
                    break;
                    Item i;
                case Character.Movement.Up:

                    if (map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Mage)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() - 1);

                        i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;

                case Character.Movement.Down:

                    if (map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Mage)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() + 1);



                        i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;

                case Character.Movement.Left:


                    if (map.GetXY(C.GetX() - 1, C.GetY() ).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() - 1, C.GetY() ).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Mage)

                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() - 1);
                    }





                    i = map.GetItemAtPosition(C.GetX(), C.GetY());

                    if (i != null)
                    {
                        C.PickUp(i);
                    }
                    break;

                case Character.Movement.Right:

                    if (map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Mage)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() + 1);


                        i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;


                default:
                    break;
            }

            //Fills the players new position by setting the tile type
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Hero);
            return PlayerMoves;
        }


       public void GoldPickup()
        {
            for (int i = 0; i < map.items.Length; i++)
            {
               
                
                
                if (map.items[i].GetCurrentTileType() == Tile.TileType.Gold)
                {
                   map.hero.SetCurrentHeldGold(map.hero.GetHeldGold() + map.items[i].getCurrentGold());

                }
            }
        }


        // updates the map and tiles where the enemy moves
        public bool MoveEnemy(Character C, Character.Movement m)
        {

            Enemymoves = true;
            //Moves the player if able

            switch (m)
            {

                case Character.Movement.Up:
                    if (map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Hero)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() - 1);
                    }
                    break;

                case Character.Movement.Down:
                    if (map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Hero)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() + 1);
                    }
                    break;

                case Character.Movement.Left:
                    if (map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Hero)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() - 1);
                    }

                    break;

                case Character.Movement.Right:
                    if (map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Hero)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() + 1);
                    }
                    break;


                default:
                    break;
            }
            //Fills the enemies new position by setting the tile type
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Enemy);
            return Enemymoves;
        }


        //creates some random numbers to determine with where the enemies are going to move 
        public void MoveEnemies(Character h)
        {
            Random random = new Random();
            int move;

            Tile[] pTile = new Tile[map.enemies.Length];
            //creates a random number for the specific enemy which creates a movies
            for (int i = 0; i < map.enemies.Length; i++)
            {

              move = random.Next(0, 5);
                if (map.enemies[i].GetCurrentTileType() == Tile.TileType.Enemy)

                {


                    switch (move)
                    {
                        case 0:
                            MoveEnemy(map.enemies[i], Character.Movement.NoMovement);
                            break;

                        case 1:

                            MoveEnemy(map.enemies[i], Character.Movement.Up);


                            break;

                        case 2:

                            MoveEnemy(map.enemies[i], Character.Movement.Down);


                            break;

                        case 3:

                            MoveEnemy(map.enemies[i], Character.Movement.Left);



                            break;

                        case 4:


                            MoveEnemy(map.enemies[i], Character.Movement.Right);


                            break;

                        default:

                            break;
                    }
                }

                EnemyAttacks(map.enemies[i]);
            }





        }

       // allows the enemies to attack to attack the player
       
        public void EnemyAttacks(Character C) 
        {

            for (int i = 0; i < map.enemies.Length; i++)
            {
                if (C.CheckRange(C, map.hero) == true)
                {
                    C.Attack(map.hero);

                }
                else if (C.CheckRange(C, map.enemies[i]) == true)
                {
                    C.Attack(map.enemies[i]);

                }
                else

                {

                }

            }
            
                   
          

        }
            
       

        public void Save()
        {
            //Creates the file stream called savefile
            FileStream saveFile = new FileStream(Directory.GetCurrentDirectory() + "/save.File", FileMode.Create);
            //Creates the binary writer and directs it toward the current directory
            using (BinaryWriter writer = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + "/save.File", FileMode.Create), Encoding.UTF8, false))
            {
                //Writes the values of the current maps width and height to the save file
                writer.Write(map.GetMapWidth() + ";" + map.GetMapHeight() + ";");

                //itterates through the map array and writes the tiletype of each element to the stream by first converting the enum to an int and then converting the int to a string
                for (int i = 0; i < map.GetMapWidth(); i++)
                {
                    for (int j = 0; j < map.GetMapHeight(); j++)
                    {
                        string currentTile = ((int)map.MapArray[i, j].GetCurrentTileType()).ToString();
                        writer.Write(currentTile + ",");
                    }
                }
                //Semicolon used as a symbol to split the data in the stream
                writer.Write(";");
                //Writes the length of the enemies array to the file in order to use the length as a limit for looping later
                writer.Write(map.enemies.Length);
                writer.Write(";");
                for (int i = 0; i < map.enemies.Length; i++)
                {
                    //Writes each enemy object to the stream using the ToSaveString method to convert all the required data to a string
                    writer.Write(map.enemies[i].ToSaveString() + ".");
                }
                writer.Write(";");
                writer.Write(map.hero.ToSaveString());
                writer.Write(";");
                writer.Write(map.items.Length);
                writer.Write(";");
                for (int j = 0; j < map.items.Length; j++)
                {
                    writer.Write(map.items[j].ToSaveString());
                }
                //Closes the StreamWriter
                writer.Close();
            }
            
            //Closes the Stream
            saveFile.Close();
        }

        public void Load()
        {
            //Opens the FileStream at the local directory using the GetCurrentDirectory method and is directed to saveFile
            FileStream saveFile = new FileStream(Directory.GetCurrentDirectory() + "/save.File", FileMode.Open);
            //Creates a binary reader and directs it toward saveFile
        BinaryReader reader = new BinaryReader(saveFile);
            //Creates the loaded map string and sets it equal to the readsavefile string
            string loadedmap = Convert.ToString(reader.ReadString());
            //creates the string array map data and populates each element with the apropriate string as split by the semicolon divider
            string[] MapData = loadedmap.Split(';');
            //creates the string array Regained map and populates each element with the apropriate string as split by the comma divider
            string[] RegainedMap = MapData[2].Split(',');
            int index = 0;
            //itterates through the map array height and width as denoted by the int value gained by parseing the mapdata[0] and [1] rspectively through as ints
            for (int i = 0; i < int.Parse(MapData[0]); i++)
            {
                for (int j = 0; j < int.Parse(MapData[1]); j++)
                {
                    //Sets the tile type of the specific element in map array to the apropriate type as denoted by parseing the regained map string as an int (which is read by the tiletype enum
                    map.MapArray[i, j].SetCurrentTileType((Tile.TileType)(int.Parse(RegainedMap[index])));

                    index++;
                }
            }
            int EnemyCount = int.Parse(MapData[3]);
            map.enemies = new Enemy[EnemyCount];
            string[] enemies = MapData[4].Split('.');
            for (int i = 0; i < EnemyCount; i++)
            {

                string[] data = enemies[i].Split(',');
                //The apropriate enemy type is decided by the data[0] which is reference to the enemy name, either "Swamp Creature" or "Mage"
                switch (data[0])
                {
                    case "Swamp Creature"
                    :
                        map.enemies[i] = new Swamp_Creature(int.Parse(data[1]), int.Parse(data[2]));

                        break;
                    case "Mage"
                    :
                        map.enemies[i] = new Mage(int.Parse(data[1]), int.Parse(data[2]));
                        break;
                    default:
                        break;
                }
                //Sets the specific variable value to the string value parsed as an int
                map.enemies[i].SetHP(int.Parse(data[3]));
                map.enemies[i].SetDamage(int.Parse(data[4]));
                map.enemies[i].SetCurrentHeldGold(int.Parse(data[5]));
                
            }
            string[] Hero = MapData[5].Split(',');

            map.hero = new Hero(int.Parse(Hero[4]), int.Parse(Hero[5]), Hero[0]);
            //Sets the specific variable value to the string value parsed as an int
            map.hero.SetHP(int.Parse(Hero[1]));
            map.hero.SetDamage(int.Parse(Hero[3]));
            map.hero.SetCurrentHeldGold(int.Parse(Hero[6]));
            string ItemsNum = MapData[6];
            string[] Items = MapData[7].Split('.');
            map.items = new Item[int.Parse(ItemsNum)];
            for (int k = 0; k < int.Parse(ItemsNum); k++)
            {
                string[] data = Items[k].Split(',');
                
                switch (data[0])
                {
                    case "Gold"
                    :
                        map.items[k] = new Gold(int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]));

                        break;
                  
                    default:
                        break;
                }
            }
            //Closes the reader and the stream
            reader.Close();
            saveFile.Close();
        }
    }
}
