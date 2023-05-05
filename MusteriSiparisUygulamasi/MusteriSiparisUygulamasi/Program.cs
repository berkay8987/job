using MusteriSiparisUygulamasi.Models;
using MusteriSiparisUygulamasi.Scripts;


int promptId = 0;
while (promptId != 8)
{
    string prompt = "\nActions:\n1-Create\n2-Update\n3-Delete\n4-Read\n5-CreateOrder\n6-Comment\n7-Balance\n8-Exit";
    Console.WriteLine(prompt);

    Console.Write("Select an Action> ");
    promptId = Convert.ToInt32(Console.ReadLine());

    switch (promptId)
    {
        case 1:
            CreateItemToDb c = new CreateItemToDb();
            Console.Write("Create a Customer(1) or a Product(2) ?> ");
            int _a = Convert.ToInt32(Console.ReadLine());
            if (_a == 1)
            {
                Console.Write("Enter a Name For The Customer: ");
                string name = Console.ReadLine();

                Console.Write("Enter a Phone For The Customer: ");
                string phone = Console.ReadLine();

                Customer customer = new Customer()
                {
                    Name = name,
                    Phone = phone
                };

                c.CreateCustomer(customer);
                Console.WriteLine($"Customer with Name:{customer.Name}, Phone:{customer.Phone} created!");
            }
            else if (_a == 2)
            {
                Console.Write("Enter a Name For The Product: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter a Price For The Product: ");
                int price = Convert.ToInt32(Console.ReadLine());

                Product product = new Product()
                {
                    Name = name,
                    Price = price
                };

                c.CreateProduct(product);
                Console.WriteLine($"Product with Name:{product.Name}, Phone:{product.Price} created!");
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
            break;

        case 2:
            UpdateDb u = new UpdateDb();
            Console.Write("Update a Customer(1) or a Product(2) or a Order(3) ?> ");
            int _q = Convert.ToInt32(Console.ReadLine());
            if (_q == 1)
            {
                Console.Write("Enter the Id of The Customer You Wish To Update> ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter a New Name For The Customer> ");
                string newName = Console.ReadLine();

                Console.Write("Enter a New Phone For The Customer> ");
                string newPhone = Console.ReadLine();

                u.UpdateCustomer(id, newName, newPhone);
            }
            else if (_q == 2)
            {
                Console.Write("Enter the Id of The Product You Wish To Update> ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter a New Name For The Product> ");
                string newName = Console.ReadLine();

                Console.Write("Enter a New Price For The Product> ");
                int newPrice = Convert.ToInt32(Console.ReadLine());

                u.UpdateProduct(id, newName, newPrice);
            }
            else if (_q == 3)
            {
                Console.Write("Enter the Id of The Order You Wish To Update> ");
                int oid = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the new ProductID> ");
                int pid = Convert.ToInt32(Console.ReadLine());

                u.UpdateOrder(oid, pid);
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
            
            break;

        case 3:
            DeleteFromDb d = new DeleteFromDb();
            Console.Write("Delete a Customer(1) or a Product(2) or a Order(3) ?> ");
            int _b = Convert.ToInt32(Console.ReadLine());
            if (_b == 1)
            {
                Console.Write("Delete With Id(1) or Name(2) ?> ");
                int _c = Convert.ToInt32(Console.ReadLine());
                if (_c == 1)
                {
                    Console.Write("Enter The Id Of the Customer You Wish To Delete> ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    d.DeleteCustomerFromDatabaseWithId(id);
                }
                else if (_c == 2)
                {
                    Console.Write("Enter The Name Of The Customer You Wish To Delete> ");
                    string name = Console.ReadLine();
                    d.DeleteCustomerFromDatabaseWithName(name);
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            else if (_b == 2)
            {
                Console.Write("Delete With Id(1) or Price(2) ?> ");
                int _c = Convert.ToInt32(Console.ReadLine());
                if (_c == 1)
                {
                    Console.Write("Enter The Id Of the Product You Wish To Delete> ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    d.DeleteProductFromDatabaseWithId(id);
                }
                else if (_c == 2)
                {
                    Console.Write("Enter The Price Of the Product You Wish To Delete> ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    d.DeleteProductFromDatabaseWithPrice(price);
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            else if (_b == 3)
            {
                Console.Write("Enter the Id of The Order You Want to Delete> ");
                int ordId = Convert.ToInt32(Console.ReadLine());
                d.DeleteOrderFromDatabaseWithId(ordId);
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
            break;

        case 4:
            ReadFromDb r = new ReadFromDb();
            r.ReadFromDatabase();
            break;

        case 5:
            Console.Write("Which Customer Wants to Buy (Enter Id)?> ");
            int custId = Convert.ToInt32(Console.ReadLine());

            Console.Write("The Customer Wants to Buy What?> ");
            int prodId = Convert.ToInt32(Console.ReadLine());

            CreateOrder co = new CreateOrder();
            co.CreateOrderToDb(custId, prodId);

            break;

        case 6:
            HandleComments hc = new HandleComments();
            string prmpt = "\n1-Add Comment\n2-Read Comments\n3-Go Back";
            int _acId = 0;
            while (_acId != 3)
            {
                Console.WriteLine(prmpt);
                Console.Write("Select an Action> ");
                _acId = Convert.ToInt32(Console.ReadLine());

                switch (_acId)
                {
                    case 1:
                        Console.Write("Which Customer Wants to Add a Comment? (Enter an Id)> ");
                        int _customerId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Which Product to Comment? (Enter an Id)> ");
                        int _productId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the Comment; ");
                        Console.Write("$: ");
                        string comment = Console.ReadLine();

                        hc.AddComment(_customerId, _productId, comment);
                        break;

                    case 2:
                        hc.ReadComments();
                        break;

                    case 3:
                        break;
                }

            }
            break;

        case 7:
            HandleCustomerBalance hcb = new HandleCustomerBalance();
            Console.Write("Add(1) or Remove Balance(2)?> ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Which customer (Enter Id)> ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many to add> ");
                int balanceToAdd = Convert.ToInt32(Console.ReadLine());
                hcb.AddBalanceToCustomer(id, balanceToAdd);
            }
            else if (choice == 2)
            {
                Console.Write("Which customer (Enter Id)> ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many to remove> ");
                int balanceToRemove = Convert.ToInt32(Console.ReadLine());
                hcb.RemoveBalanceFromCustomer(id, balanceToRemove);
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
            break;

        case 8:
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Wrong Input");
            break;
    }

}
