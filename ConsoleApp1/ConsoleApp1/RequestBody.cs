namespace ConsoleApp1
{
    public class RequestBody
    {
        public int Number { get;}
        public string Element { get;}
        public int I { get;}

        public RequestBody(int number)
        {
            Number = number;
            Element = "";
        }

        public RequestBody(int number, string element )
        {
            Number = number;
            Element = element;
        }
        public RequestBody(int number, string element, int i)
        {
            Number = number;
            Element = element;
            I = i;
        }
        

        
    }
}
