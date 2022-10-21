using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    public abstract class Item : Tile
    {
        int CurrentGold;
        public Item(int x, int y, TileType type, int SymbolIndex, int value) : base(x, y, type, SymbolIndex)
        {
            CurrentGold = value;
        }
        #region accessors and mutators
        public void SetCurrentGold(int currentGold)
        {
            CurrentGold = currentGold;
        }

        public int getCurrentGold()
        {
            return CurrentGold;
        }
        #endregion
        public abstract override string ToString();
    }
}
