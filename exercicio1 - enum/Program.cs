// Enunciado: Ler os dados de um pedido com N itens (N fornecido pelo usuário).
// Depois, mostrar um sumário do pedido conforme exemplo(próxima página).
// Nota: o instante do pedido deve ser o instante do sistema: DateTime.Now

using System;
using System.Globalization;
using exercicio_enum.Entities;
using exercicio_enum.Entities.Enum;

namespace ExercEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string nameClient = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());

            Client client = new Client(nameClient, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(quantity, price, product);
                order.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
        }
    }
}