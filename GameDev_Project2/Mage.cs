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
        public Mage(int x, int y) : base(x, y, 5, 5, 1, "Mage", 6, TileType.Mage)
        {

        }

        //Always returns noMovement as the mage does not move
        public override Movement ReturnMove(Movement move)
        {
            return Movement.NoMovement;
        }


        public override bool CheckRange(Character h, Tile target)
        {
            Tile[] MagesTargets = new Tile[7];
            double CurrentRange = h.GetRange();
            int CurrentDistance = CheckDistanceToTarget(h, target);
            Console.WriteLine(CurrentRange);
            for (int i = 0; i < MagesTargets.Length; i++)
            {

                if (i == 0)
                {

                    MagesTargets[i].SetX(h.GetX() - 1);
                    MagesTargets[i].SetY(h.GetY() - 1);
                    target = MagesTargets[i];

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


                else
                {
                    InRange = false;
                }
                

            }
            return InRange;
        }
    }
}
