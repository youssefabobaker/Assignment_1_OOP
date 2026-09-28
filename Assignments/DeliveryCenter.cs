
namespace Assignments
{
    internal class DeliveryCenter
    {
        private Shipment[] shipments = new Shipment[10];

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];
                else
                    return default;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                    shipments[index] = value;
           
            }
        }

        public Shipment this[String trackingCode]
        {
            get
            {
                foreach (var shipment in shipments)
                {
                    if (shipment.TrackingCode == trackingCode)
                        return shipment;
                }
                return default;
            }
        }


        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }
    }
}
