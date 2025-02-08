
using System.Collections.ObjectModel;

enum Status { 
    COMPLETED, CANCELED, PENDING, ACCEPTED
}

class Program {

    class Order {

        private Status status;
        private List<string> products;
        public Order(Status status, List<string> products) {
            this.status = status;
            this.products = products;
        }

        public Status getStatus() {
            return this.status;
        }

        public void setStatus(Status status) {
            if (status == this.status) {
                throw new ArgumentException("You cannot change status to thw same status"); // można wyrzucić ten wyjątek ale po co skoro łatwo można go obsłuzyć?
            }
            this.status = status;
        }

        public string toString() {
            return $"Order : [status : {this.status}, products : {getProductsString()}]";
        }

        private string getProductsString() {
            string result = "";
            this.products.ForEach(p => result += p + " ");
            return result;
        }
    }

    static void printOrders(List<Order> orders) {
        Console.WriteLine("List of orders : ");
        orders.ForEach((o) => Console.WriteLine(o.toString()));
    }

    static void changeStatusUsingConsole(Order order)
    {

        Status status;
        bool flag = true;
        string readedStatus = "";
        while (flag)
        {
            Console.WriteLine("Give status value to change : ");
            readedStatus = Console.ReadLine();

            if (Enum.IsDefined(typeof(Status), readedStatus) && order.getStatus().ToString() != readedStatus) {
                flag = false;
            }else if (order.getStatus().ToString() == readedStatus) {
                Console.WriteLine("This value is already set");
            }
            else {
                Console.WriteLine("Given value is not acceptable. Remember that you have to give name of status UPPERCASE!");
            }
        }
        order.setStatus((Status) Enum.Parse(typeof(Status), readedStatus));
        
    }

    public static void Main(String[] args)
    {
        List<Order> orders = new List<Order>();
        
        List<string> products1 = new List<string>() { "pomarańcza", "jabłko", "cytryna" };
        List<string> products2 = new List<string>() { "jajko", "ser", "szynka" };
        List<string> products3 = new List<string>() { "szynka", "ryba", "kurczak" };
        
        Order order1 = new Order(Status.PENDING, products1);
        Order order2 = new Order(Status.ACCEPTED, products2);
        Order order3 = new Order(Status.COMPLETED, products3);

        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        orders.ForEach(o => changeStatusUsingConsole(o));
    
        printOrders(orders); 
    }


}
