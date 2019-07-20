namespace ConsoleApp1
{
    class Item
    {
        public ColorShade color { get; set; }
    }

    public enum ColorShade
    {
        White,
        Black,
        Red,
        Blue,
        Green
    }

    class ParentItem
    {
        public Item Item { get; set; }
        public ParentItem(Item item)
        {
            Item = item;
        }
    }
}
