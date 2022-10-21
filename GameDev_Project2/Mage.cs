using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
   public class Mage : Enemy
    {
        //Constructor for the mage object
        public Mage(int x, int y) : base(x, y, 5, 5, 1, "Mage",6,TileType.Mage)
        {

        }
        
        //Always returns noMovement as the mage does not move
        public override Movement ReturnMove(Movement move)
        {         
            return Movement.NoMovement;
        }


    /*    public override bool CheckRange(Character h, Tile target)
        {
            //Sets the Inrange boolean to false as the default everytime checkrange begins
            InRange = false;

            //Creates a Tile array that stores all tiles that fall within the mages attack radius

            Tile[] MagesTargets = new Tile[7];

            //populates the MagesTargets tile array with the correct tiles by setting the co-ordinates of each of the apropriate tiles within the array with reference to the apropriate mages co-ordinates (Mage being the character h)
            for (int i = 0; i < MagesTargets.Length; i++)
            {
                if(i == 0)
                {
                    MagesTargets[i].SetX(h.GetX() - 1);
                    MagesTargets[i].SetY(h.GetY() - 1);
                }

                if (i == 1)
                {
                    MagesTargets[i].SetX(h.GetX());
                    MagesTargets[i].SetY(h.GetY() - 1);
                }

                if (i == 2)
                {
                    MagesTargets[i].SetX(h.GetX() + 1);
                    MagesTargets[i].SetY(h.GetY() - 1);
                }

                if (i == 3)
                {
                    MagesTargets[i].SetX(h.GetX() - 1);
                    MagesTargets[i].SetY(h.GetY());
                }

                if (i == 4)
                {
                    MagesTargets[i].SetX(h.GetX() + 1);
                    MagesTargets[i].SetY(h.GetY());
                }

                if (i == 5)
                {
                    MagesTargets[i].SetX(h.GetX() - 1);
                    MagesTargets[i].SetY(h.GetY() + 1);
                }

                if (i == 6)
                {
                    MagesTargets[i].SetX(h.GetX());
                    MagesTargets[i].SetY(h.GetY() + 1);
                }

                if (i == 7)
                {
                    MagesTargets[i].SetX(h.GetX() + 1);
                    MagesTargets[i].SetY(h.GetY() + 1);
                }
            }
            //Compares the tile type of each of the tiles within the MagesTargets array and if they are a suitable type (Hero or Enemy) sets the InRange boolean to true
            for (int j = 0; j < MagesTargets.Length; j++)
            {
                if(MagesTargets[j].GetCurrentTileType() == TileType.Enemy || MagesTargets[j].GetCurrentTileType() == TileType.Hero)
                {
                    InRange = true;
                }
            }
            
            //returns the InRange boolean
            return InRange;
        }
    */
    }
}
