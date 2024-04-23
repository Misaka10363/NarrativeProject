namespace NarrativeProject
{
    internal abstract class Item
    {
        private string itemName;
        internal bool isWeapon;
        internal int damage;
        internal abstract void CreateDescription();
        internal abstract string getItemName();
    }
}
