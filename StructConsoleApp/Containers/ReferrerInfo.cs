namespace StructConsoleApp.Containers
{
    public struct ReferrerInfo
    {
        public char Language;
        public string ConfirmAnswer;
        public string ConfirmReturnToMainMenu;
        public Item Item;
        public override string ToString() => Language.ToString();

    }

    public class Item
    {
        public string Value { get; set; }
    }
}
