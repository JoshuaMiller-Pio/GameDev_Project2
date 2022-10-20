using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    internal class Gold:Item
    {
       
       private int CurrentGold;
       private Random random;


        public Gold(int x, int y, int ValueOfGold ):base(x,y, TileType.Gold, 2)
        {
            random = new Random();
            ValueOfGold = random.Next(1, 6);
            

        }

        #region accessors and mutators
        private void setCurrentGold(int gold)
        {
          CurrentGold = gold;  
        }

        public int getCurrentGold() 
        {
            return CurrentGold;
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Current Gold:{1}",getCurrentGold());
        }

    }
}
