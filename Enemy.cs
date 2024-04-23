using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal abstract class Enemy
    {
        private int health;
        private int damage;
        internal abstract int doDamage();
        internal abstract void recieveDamage(int i);
        internal abstract void Talk();
    }
}
