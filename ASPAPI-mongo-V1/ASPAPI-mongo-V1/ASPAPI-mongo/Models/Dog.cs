namespace ASPAPI_mongo.Models
{
    public class Dog
    {
        public string breed { get; set; }
        public string color { get; set; }
        public int age { get; set; }

        public Dog(string pBreed, string pColor, int pAge)
        {
            breed = pBreed;
            color = pColor;
            age = pAge;
        }
    }
}
