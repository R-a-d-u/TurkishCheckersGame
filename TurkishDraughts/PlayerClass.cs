namespace TurkishDraughts
{
    internal class PlayerClass
    {
        private String name;

        public PlayerClass(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }
}