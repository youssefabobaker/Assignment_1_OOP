namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Question 1
            // public struct DeliveryAddress { string City; public string Street; }
            // public class Customer { public string Name; }

            // when a DeliveryAddress variable is copied into another variable --> a new copy is created by copying the data/values 
            // when copy is modified --> the original variable is not modified, the copy is modified

            // when a Customer variable is copied into another variable --> a new reference is created that points to the same object in memory
            // when one variable modifies the object --> the other variable also sees the change
            #endregion

            #region Question 2
            //public struct Shipment { public string Description; public double Weight; public decimal DeliveryFee;}

            // three problems with this design from an encapsulation perspective --> 1- All fields are public 2- There are no methods to manipulate the data to do validations 3- can't prevent the set and remain the get or vice versa

            // private fields and public properties improve this design? --> we can control how the data is accessed and ensure that it is always in a valid state.
            #endregion

            #region 1. Create a DeliveryAddress struct with:
            //DeliveryAddress address1 = new DeliveryAddress("New York", "5th", 123);
            //DeliveryAddress address2 = address1; 

            //Console.WriteLine($"Address 1: {address1.GetFullAddress()}");
            //Console.WriteLine($"Address 2: {address2.GetFullAddress()}");

            //address2.City = "Los Angeles";

            //Console.WriteLine($"Address 1: {address1.GetFullAddress()}");
            //Console.WriteLine($"Address 2: {address2.GetFullAddress()}");
            #endregion

            #region 2.Ceate a Shipment struct
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i + 1} Data");
                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine()!;
                Console.Write("Description: ");
                string description = Console.ReadLine()!;
                Console.Write("Weight: ");
                double weight = double.Parse(Console.ReadLine()!);
                Console.Write("Delivery Fee: ");
                decimal deliveryFee = decimal.Parse(Console.ReadLine()!);
                Console.Write("City: ");
                string city = Console.ReadLine()!;
                Console.Write("Street: ");
                string street = Console.ReadLine()!;
                Console.Write("Bulding Number: ");
                int number = int.Parse(Console.ReadLine()!);
                DeliveryAddress destination = new DeliveryAddress(city, street, number);
                Shipment shipment = new Shipment(trackingCode, description, weight, deliveryFee, destination);
                bool isAdded = deliveryCenter.AddShipment(shipment);
                if (isAdded)
                {
                    Console.WriteLine("Shipment added successfully.");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Failed to add shipment.");
                    Console.WriteLine();

                }
            }
            
            Console.WriteLine("--- All Shipments ---");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Shipment {i + 1} Details:");
                Shipment shipment = deliveryCenter[i];
                shipment.PrintShipment();
                Console.WriteLine();
            }

            Console.Write("enter Tracking code to search: ");
            string searchTrackingCode = Console.ReadLine()!;
            Shipment SearchedShipmint = deliveryCenter[searchTrackingCode];
            if (SearchedShipmint.TrackingCode != null)
            {
                Console.WriteLine("Shipment found:");
                SearchedShipmint.PrintShipment();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }

            Console.WriteLine("--- Struct Copy Test ---");
            DeliveryAddress Copied = deliveryCenter[0].Destination;

            Console.WriteLine($"Original Address : {deliveryCenter[0].Destination.GetFullAddress()}");
            Console.WriteLine($"Copied Address : {Copied.GetFullAddress()}");

            Copied.BuildingNumber = 20;
            Copied.Street = "Makram Ebeid";

            Console.WriteLine($"Original Address : {deliveryCenter[0].Destination.GetFullAddress()}");
            Console.WriteLine($"CopiedAddress : {Copied.GetFullAddress()}");
            #endregion
        }
    }
}
