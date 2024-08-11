namespace Ado_Task_2
{
    public class Car
    {
        public Car(int id, string model, string marka)
        {
            Id = id;
            Model = model;
            Marka = marka;
        }

        public Car() 
        { 
        
        }

        public int Id { get; set; }
        public string Model {  get; set; }
        public string Marka { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Model}\t{Marka}";
        }
    }
}
