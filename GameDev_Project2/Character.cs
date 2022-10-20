using System;

namespace GameDev_Project2
{
    public abstract class Character : Tile
    {
        #region DECLARATIONS
        protected double HP;
        protected double MaxHP;
        protected double Damage;
        protected double Range;
        protected char symbol;
        protected double heldGold;
        protected TileType type;
        protected Movement move;
        public Tile[,] CharacterVision;
        private int DistanceToTargetX;
        private int DistanceToTargetY;
        private bool isDead;
        public String CharacterName;
        public bool InRange;
        private int CurrentGameWidth;
        private int ActualDistance;
        private int ActualDistanceX;
        private int ActualDistanceY;

        //public Movement 
        public enum Movement
        {
            NoMovement, Up, Down, Left, Right
        }

        //Constructor for Character
        public Character(int x, int y, TileType type, int symbolIndex, double MaxHP, double Damage, double Range, double heldGold) : base(x, y, type, symbolIndex)
        {
            this.MaxHP = MaxHP;
            this.HP = MaxHP;
            this.Damage = Damage;
            this.Range = Range;
        }
        #endregion

        #region ACCESSORS AND MUTATORS
        //=============================//
        //   ACCESSORS AND MUTATORS    //
        //=============================//

        //Region contains all methods used to change variable values
        #region MUTATOR METHODS
        public void SetHP(double HP)
        {
            this.HP = HP;
        }

        public void SetCurrentHeldGold(double HeldGold)
        {
            this.heldGold = HeldGold;
        }
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }
        public void SetMaxHP(double MaxHP)
        {
            this.MaxHP = MaxHP;
        }

        public void SetMove(Movement move)
        {
            this.move = move;
        }

        public void SetDamage(double Damage)
        {
            this.Damage = Damage;
        }

        public void SetName(String name)
        {
            this.CharacterName = name;
        }

        public void SetRange(double Range)
        {
            this.Range = Range;

        }
        #endregion

        //Region contains all methods used to access variable values
        #region ACCESSORS METHODS
        public double GetHP()
        {
            return HP;
        }

        public double GetHeldGold()
        {
            return heldGold;
        }
        public char GetSymbol()
        {
            return symbol;
        }
        public Movement GetMove()
        {
            return move;
        }
        public double GetMaxHP()
        {
            return MaxHP;
        }

        public double GetDamage()
        {
            return Damage;
        }

        public String GetName()
        {
            return CharacterName;
        }

        public double GetRange()
        {
            return Range;

        }
        #endregion

        #endregion

        public virtual void Attack(Character target)
        {
            target.SetHP(target.GetHP()-GetDamage());
        }

        //gets value from movment-num to move a character
        public void Move(Movement move)
        {
            if (move == Movement.Left)
            {
                int x = GetX();

                x = x - 1;
                SetX(x);
            }
            if (move == Movement.Right)
            {
                int x = GetX();

                x = x + 1;
                SetX(x);
                
            }
            if (move == Movement.Up)
            {
                int y = GetY();

                y = y - 1;
                SetY(y);
            }
            if (move == Movement.Down)
            {
                int y = GetY();

                y = y + 1;
                SetY(y);
            }
            if (move == Movement.NoMovement)
            {
                return;
            }
        }

        //checks if the character is dead or not
        public bool CheckisDead(Character Target)
        {
            if (Target.GetHP() <= 0)
            {
                isDead = true;

            }
            else
            {
                isDead = false;
            }

            return isDead;
        }

        //Gets the Hero's and a targets position, then calculates the distance between them
        public int CheckDistanceToTarget(Character c, Tile target)
        {
            int CharacterX = c.GetX();
            int CharacterY = c.GetY();

            int targetX = target.GetX();
            int targetY = target.GetY();

            DistanceToTargetX = CharacterX - targetX;
            DistanceToTargetY = CharacterY - targetY;

            ActualDistanceX = 0;

            if (DistanceToTargetX > 0 && DistanceToTargetX <= CurrentGameWidth + 1)
            {
                ActualDistanceX = 1;
            }
            if (DistanceToTargetX > 0 && DistanceToTargetX <= CurrentGameWidth * 2 + 1)
            {
                ActualDistanceX = 2;
            }

            ActualDistanceY = DistanceToTargetY;
            ActualDistance = DistanceToTargetX + DistanceToTargetY;
            return ActualDistance;
        }

        public virtual bool CheckRange(Character h, Tile target)
        {
            double CurrentRange = h.Range;
            int CurrentDistance = CheckDistanceToTarget(h, target);
            if (CurrentDistance <= CurrentRange)
            {
                InRange = true;
            }
            else
            {
                InRange = false;
            }
            return InRange;
        }

        public void PickUp(Item i)
        {
            if(i.GetCurrentTileType() == TileType.Gold)
            {
                Gold g = (Gold)i;

                SetCurrentHeldGold(GetHeldGold() + g.getCurrentGold());
            }
        }
        public abstract override string ToString();


        public abstract Movement ReturnMove(Movement move = 0);
    }
}