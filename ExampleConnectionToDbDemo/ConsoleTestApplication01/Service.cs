namespace ConsoleTestApplication01
{
    internal class Service
    {
        internal Service(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        
        internal int Id { get; set; }
        internal string Name { get; set; }
    }
}
