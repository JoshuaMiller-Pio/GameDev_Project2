using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    public abstract class Tile
    {
        protected int X;
        protected int Y;
        protected TileType type;
        protected char[] Symbols = new char[7] { 'H', 'E', 'G', 'W', '#', '.', 'M'};
        protected char Symbol;
        public enum TileType
        {
            Hero, Enemy, Gold, Weapon, Border, Empty
        };

        //Region contains all methods used to change variable values
        #region Mutator methods
        public void SetX(int X)
        {
            this.X = X;
        }

        public void SetY(int Y)
        {
            this.Y = Y;
        }

        public void SetCurrentTileType(TileType type)
        {
            this.type = type;
        }

        public void SetCurrentSymbol()
        {
            this.Symbol = Symbols[5];
        }
        #endregion

        //Region contains all the methods used to retrieve variable values
        #region Accessor Methods
        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public TileType GetCurrentTileType()
        {
            return type;
        }

        public char GetCurrentSymbol()
        {
            return Symbol;
        }
        #endregion

        //Basic contructor for the Tile object class
        public Tile(int X, int Y, TileType type, int symbolIndex)
        {
            this.X = X;
            this.Y = Y;
            this.type = type;
            Symbol = Symbols[symbolIndex];
        }
    }
}
