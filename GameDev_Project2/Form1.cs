using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        public Form1()
        {
            InitializeComponent();

            gameEngine = new GameEngine();
            display();
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


            for (int x = 0; x < gameEngine.map.GetMapWidth(); x++)
            {
                for (int y = 0; y < gameEngine.map.GetMapHeight(); y++)
                {
                    textBoxes[y, x].Text = gameEngine.map.GetXY(y, x).GetCurrentSymbol().ToString();
                }
            }
        }

        private void txtUserInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1050, 1000);

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
            Console.WriteLine(gameEngine.ShowMap());

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
        }

        //looks down
        private void btnDown_Click(object sender, EventArgs e)
        {
            int hightlighty;
            int highlightx;

            hightlighty = gameEngine.map.hero.GetY() + 1;
            highlightx = gameEngine.map.hero.GetX();
            Hightlight(highlightx, hightlighty);

        }
        //rlooks to the right
        private void btnRight_Click(object sender, EventArgs e)
        {
            int hightlighty;
            int highlightx;
            hightlighty = gameEngine.map.hero.GetY();
            highlightx = gameEngine.map.hero.GetX() + 1;
            Hightlight(highlightx, hightlighty);
        }
        //looks to the left
        private void btnLeft_Click(object sender, EventArgs e)
        {

            //gameEngine.map.hero.SetMove(Character.Movement.Left);
            // gameEngine.map.hero.ReturnMove(Character.Movement.Left);

            int hightlighty;
            int highlightx;
            hightlighty = gameEngine.map.hero.GetY();
            highlightx = gameEngine.map.hero.GetX() - 1;
            Hightlight(highlightx, hightlighty);

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
            move();
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
            //selectedX
            EX = selectedX + 1;
            EY = selectedY + 1;


            for (int i = 0; i <= gameEngine.map.enemies.Length - 1; i++)
            {
                if (gameEngine.map.enemies[i].GetX() + 1 == EX && gameEngine.map.enemies[i].GetY() + 1 == EY)
                {

                    gameEngine.map.hero.Attack(gameEngine.map.enemies[i], gameEngine.map.hero);



                    if (gameEngine.map.enemies[i].CheckisDead(gameEngine.map.enemies[i]) == true)
                    {
                        gameEngine.map.enemies[i].SetCurrentTileType(Tile.TileType.Empty);
                        textBoxes[gameEngine.map.enemies[i].GetY(), gameEngine.map.enemies[i].GetX()].Text = ".";
                    }

                }
            }


        }
        //allows the hero to move
        private void move()
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
            int MX, MY;
            MX = selectedY;
            MY = selectedX;

            if (textBoxes[MY, MX].Text != "#" && textBoxes[MY, MX].Text != "E")
            {
                int NewX, oldX, NewY, oldY;

                oldX = gameEngine.map.hero.GetX();
                oldY = gameEngine.map.hero.GetY();

                NewX = MX;
                NewY = MY;

                gameEngine.map.hero.SetX(NewY);
                gameEngine.map.hero.SetY(NewX);
                textBoxes[gameEngine.map.hero.GetY(), gameEngine.map.hero.GetX()].Text = "H";
                textBoxes[oldY, oldX].Text = ".";
                Console.WriteLine(gameEngine.map.hero.GetX() + " " + gameEngine.map.hero.GetY());

            }


        }




    }
}