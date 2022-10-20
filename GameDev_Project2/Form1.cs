using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  GameDev_Project2

{
    public partial class Form1 : Form
    {
        public static GameEngine gameEngine;
        public int selectedX;
        public int selectedY;
        Character.Movement move;

        public Form1()
        {
            InitializeComponent();

            gameEngine = new GameEngine();
            display();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1050, 1000);

           
            Updatestats();
           
        }

        //displays the map
        public void display()
        {
            TextBox[,] textBoxes =
            {
                { txt00,txt10,txt20,txt30,txt40,txt50,txt60,txt70,txt80,txt90},
                { txt01,txt11,txt21,txt31,txt41,txt51,txt61,txt71,txt81,txt91},
                { txt02,txt12,txt22,txt32,txt42,txt52,txt62,txt72,txt82,txt92},
                { txt03,txt13,txt23,txt33,txt43,txt53,txt63,txt73,txt83,txt93},
                { txt04,txt14,txt24,txt34,txt44,txt54,txt64,txt74,txt84,txt94},
                { txt05,txt15,txt25,txt35,txt45,txt55,txt65,txt75,txt85,txt95},
                { txt06,txt16,txt26,txt36,txt46,txt56,txt66,txt76,txt86,txt96},
                { txt07,txt17,txt27,txt37,txt47,txt57,txt67,txt77,txt87,txt97},
                { txt08,txt18,txt28,txt38,txt48,txt58,txt68,txt78,txt88,txt98}
            };

            //defult starting map
            for (int x = 0; x < gameEngine.map.GetMapWidth(); x++)
            {
                for (int y = 0; y < gameEngine.map.GetMapHeight(); y++)
                {
                    textBoxes[y,x].Text = gameEngine.map.GetXY(x, y).GetCurrentSymbol().ToString();
                }
            }
            //hides blanked blocks
        
            for (int i = 0; i <= 9; i++)
            {

                for (int j = 0; j <= 8; j++)
                {
                    if (textBoxes[j, i].Text == "")
                    {
                        textBoxes[j, i].Hide();
                    }

                }
            }
        }

        //looks up
        private void btnUp_Click(object sender, EventArgs e)
        {
            int hightlighty;
            int highlightx;
            hightlighty = gameEngine.map.hero.GetY() - 1;
            highlightx = gameEngine.map.hero.GetX();
            Hightlight(highlightx, hightlighty);
            move = Character.Movement.Up;
        }

        //looks down
        private void btnDown_Click(object sender, EventArgs e)
        {
            int hightlighty;
            int highlightx;

            hightlighty = gameEngine.map.hero.GetY() + 1;
            highlightx = gameEngine.map.hero.GetX();
            Hightlight(highlightx, hightlighty);
            move = Character.Movement.Down;
        }
        //rlooks to the right
        private void btnRight_Click(object sender, EventArgs e)
        {
            int hightlighty;
            int highlightx;
            hightlighty = gameEngine.map.hero.GetY();
            highlightx = gameEngine.map.hero.GetX() + 1;
            Hightlight(highlightx, hightlighty);
            move = Character.Movement.Right;

        }
        //looks to the left
        private void btnLeft_Click(object sender, EventArgs e)
        {



            int hightlighty;
            int highlightx;
            hightlighty = gameEngine.map.hero.GetY();
            highlightx = gameEngine.map.hero.GetX() - 1;
            Hightlight(highlightx, hightlighty);
            move = Character.Movement.Left;

        }










        //creates the highlight for where the hero is aiming
        public void Hightlight(int highlightx, int highlighty)
        {
            TextBox[,] textBoxes =
          {
                {txt00,txt10,txt20,txt30,txt40,txt50,txt60,txt70,txt80,txt90},
                {txt01,txt11,txt21,txt31,txt41,txt51,txt61,txt71,txt81,txt91},
                {txt02,txt12,txt22,txt32,txt42,txt52,txt62,txt72,txt82,txt92},
                {txt03,txt13,txt23,txt33,txt43,txt53,txt63,txt73,txt83,txt93},
                {txt04,txt14,txt24,txt34,txt44,txt54,txt64,txt74,txt84,txt94},
                {txt05,txt15,txt25,txt35,txt45,txt55,txt65,txt75,txt85,txt95},
                {txt06,txt16,txt26,txt36,txt46,txt56,txt66,txt76,txt86,txt96},
                {txt07,txt17,txt27,txt37,txt47,txt57,txt67,txt77,txt87,txt97},
                {txt08,txt18,txt28,txt38,txt48,txt58,txt68,txt78,txt88,txt98}
            };

            for (int i = 0; i <= 9; i++)
            {

                for (int j = 0; j <= 8; j++)
                {
                    textBoxes[j, i].BackColor = Color.White;

                }
            }

            if (textBoxes[highlighty, highlightx].Text == "#")
            {
                textBoxes[highlighty, highlightx].BackColor = Color.Red;
            }
            else
            {
                textBoxes[highlighty, highlightx].BackColor = Color.Cyan;
            }
            selectedX = highlightx;
            selectedY = highlighty;
        }

        private void btnMove_Click_1(object sender, EventArgs e)
        {
            Move();
        }

        //allows the hero to attack
        private void btnAttack_Click_1(object sender, EventArgs e)
        {
            int EX, EY, EX1, EY1;

            //Hightlight(selectedX,selectedY);
            TextBox[,] textBoxes =
          {
                {txt00,txt10,txt20,txt30,txt40,txt50,txt60,txt70,txt80,txt90},
                {txt01,txt11,txt21,txt31,txt41,txt51,txt61,txt71,txt81,txt91},
                {txt02,txt12,txt22,txt32,txt42,txt52,txt62,txt72,txt82,txt92},
                {txt03,txt13,txt23,txt33,txt43,txt53,txt63,txt73,txt83,txt93},
                {txt04,txt14,txt24,txt34,txt44,txt54,txt64,txt74,txt84,txt94},
                {txt05,txt15,txt25,txt35,txt45,txt55,txt65,txt75,txt85,txt95},
                {txt06,txt16,txt26,txt36,txt46,txt56,txt66,txt76,txt86,txt96},
                {txt07,txt17,txt27,txt37,txt47,txt57,txt67,txt77,txt87,txt97},
                {txt08,txt18,txt28,txt38,txt48,txt58,txt68,txt78,txt88,txt98}
            };
            
            EX = selectedX + 1;
            EY = selectedY + 1;


            for (int i = 0; i <= gameEngine.map.enemies.Length - 1; i++)
            {
                if (gameEngine.map.enemies[i].GetX() + 1 == EX && gameEngine.map.enemies[i].GetY() + 1 == EY)
                {

                    gameEngine.map.hero.Attack(gameEngine.map.enemies[i]);
                    Updatestats();

                    


                    if (gameEngine.map.enemies[i].CheckisDead(gameEngine.map.enemies[i]) == true)
                    {
                        gameEngine.map.enemies[i].SetCurrentTileType(Tile.TileType.Empty);
                        textBoxes[gameEngine.map.enemies[i].GetY(), gameEngine.map.enemies[i].GetX()].Text = ".";
                    }
                }
            }
            
            updatemap();
            
            gameEngine.EnemyAttacks();

        }
        //allows the hero to move
        private void Move()
        {
            
           gameEngine.MovePlayer(gameEngine.map.hero, move);
            Console.WriteLine((gameEngine.map.enemies[0].CheckDistanceToTarget(gameEngine.map.enemies[0], gameEngine.map.hero)));
            //  gameEngine.MoveEnemies(gameEngine.map.hero);
           gameEngine.EnemyAttacks();
            updatemap();
            
            Updatestats();

        }

        private void Updatestats()
        {
            txtStats.Text = gameEngine.map.hero.ToString() + "\n";
            for (int i = 0; i < 74; i++)
            {
                txtStats.AppendText("-");
            }
            for (int i = 0; i < gameEngine.map.enemies.Length; i++)
            {
                txtStats.AppendText("-");
                txtStats.AppendText("\n" + gameEngine.map.enemies[i].ToString());
            }
                                             

        }
        private void HeroGameOver()
        {
            if (gameEngine.map.hero.CheckisDead(gameEngine.map.hero) == true)
            {
                MessageBox.Show("Game Over");
                btnAttack.Enabled = false;
                btnDown.Enabled = false;
                btnUp.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnMove.Enabled = false;
            }
        }
        public void updatemap()
            {
                TextBox[,] textBoxes =
          {
                {txt00,txt10,txt20,txt30,txt40,txt50,txt60,txt70,txt80,txt90},
                {txt01,txt11,txt21,txt31,txt41,txt51,txt61,txt71,txt81,txt91},
                {txt02,txt12,txt22,txt32,txt42,txt52,txt62,txt72,txt82,txt92},
                {txt03,txt13,txt23,txt33,txt43,txt53,txt63,txt73,txt83,txt93},
                {txt04,txt14,txt24,txt34,txt44,txt54,txt64,txt74,txt84,txt94},
                {txt05,txt15,txt25,txt35,txt45,txt55,txt65,txt75,txt85,txt95},
                {txt06,txt16,txt26,txt36,txt46,txt56,txt66,txt76,txt86,txt96},
                {txt07,txt17,txt27,txt37,txt47,txt57,txt67,txt77,txt87,txt97},
                {txt08,txt18,txt28,txt38,txt48,txt58,txt68,txt78,txt88,txt98}
            };

                for(int i = 0; i< gameEngine.map.GetMapHeight()-1; i++)
                {
                     for (int j = 0; j < gameEngine.map.GetMapWidth()-1; j++)
                     { 
                        Tile.TileType type;
                        type = gameEngine.map.GetXY(j,i).GetCurrentTileType();
                        switch (type)
                        {
                            case Tile.TileType.Hero:
                            textBoxes[i, j].Text = "H";
                            break;

                            case Tile.TileType.Empty:
                            textBoxes[i, j].Text = ".";
                            break;

                            case Tile.TileType.Enemy:
                            textBoxes[i, j].Text = "E";
                            break;

                            default:
                            break;
                        }
                     }
                
                }
          //  HeroGameOver();
        }

    }
}