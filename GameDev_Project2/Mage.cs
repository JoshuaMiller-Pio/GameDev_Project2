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


        public override bool CheckRange(Character h, Tile target)
        {
         
            double CurrentRange = h.GetRange();
            int CurrentDistance = CheckDistanceToTarget(h, target);
            Console.WriteLine(CurrentRange);
            if (CurrentDistance == CurrentRange || (CurrentDistance * -1) == CurrentRange)
            {
                InRange = true;
            }
            else
            {
                InRange = false;
            }
            return InRange;
        
    }
    
    }
}
