using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    internal class Gold:Item
    {
       private int currentgold;
       private Random random;

        public Gold(int x, int y, int CurrentGold ):base(x,y, TileType.Gold, 3)
        {
            random = new Random();
            CurrentGold = random.Next(1, 6);
            currentgold = CurrentGold;
        }

        #region accessors and mutators
        private void setCurrentGold(int gold)
        {
          currentgold = gold;  
        }

        public int getCurrentGold() 
        {
            return currentgold;
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Current Gold:{1}",this.getCurrentGold());
        }

    }
}
