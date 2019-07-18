using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo funciona hasta ahora//
            //SearchAndDelete();
            //SearchAndDeleteOrdersID();
            //SearchAndDeleteOrdersbyCustomerID();
            //AgregarCliente();
            //RetrieveAndUpdate();
            //AddOrder();
            //List();
            Console.WriteLine("Presiones<enter> para finalizar");
            Console.ReadLine();
        }
        static void AgregarCliente()
        {
            Customer c = new Customer()
            {
                Id=0,
                FirstName = "girl",
                LastName = "gal",
                StreetAddress = "granillo",
                City = "San Miguel",
                Phone = "59595",
                Email = "girlsgall@gmail.com"
               

            };
            
            //Order Cereal = new Order
            //{
            //    OrderFullFilled = true,
                
                
            //};
            //c.Orders.Add(Cereal);

            using (var r = RepositoryFactory.CreateRepository())//Todo lo que esta en el using se libera los recurso, se invoca el dispos
            {
                r.Create(c);
            }
            Console.WriteLine
                    ($"Cliente: {c.FirstName}" + $" Apellido: {c.LastName}" /*+ $"Producto:{Cereal.OrderFullFilled}"*/);
            Console.WriteLine("cliente creado exitosamente");
        }

        static void AddOrder()
        {
            //solo se pueden agrgar ordenes si existe el id de clientes
            Order Avena = new Order
            {
                Id = 5,
                OrderPlaced = System.TimeSpan.Parse("11:43:23.45"),
                OrderFullFilled = false,
                Customerid = 0         
                
            };
            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(Avena);
            }
            Console.WriteLine($"Producto:{Avena.Id}");
        }
        //Buscar y Modificar
        static void RetrieveAndUpdate()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Buscar el ultimo producto agregado
                Customer P = r.Retrieve<Customer>(p => p.Id== 0);
                if (P != null)
                {
                    Console.Write(P.City + "es ahora: ");
                    P.City = "Carolina";
                    Console.WriteLine(P.City);
                    r.Update(P);
                    Console.WriteLine("Sea modificado correctamente");

                }
            }
        }

        static void List()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var customer = r.Filter<Customer>(c => c.City.Contains("caro"))
                .OrderByDescending(p => p.City);
                //var products = r.Filter<Product>(p => p.ProductName.Contains("ae"))
                //.OrderByDescending(p => p.ProductName);
                //var order = r.Filter<Order>(p => true);
                //foreach (var P in products)
                //{
                //    Console.WriteLine($"{P.ProductName}");
                //}
                //Inne Join
                var ListProduct = from prod in customer
                                  join cate in customer on prod.Id equals cate.Id
                                  select new
                                  {
                                      productsname = prod.FirstName,
                                      categoriesname = cate.City
                                  };
                foreach (var P in ListProduct)
                {
                    Console.WriteLine($"{P.productsname} , {P.categoriesname}");
                }
            }

        }

        //static void List()
        //{
        //    using (var r = RepositoryFactory.CreateRepository())
        //    {
        //        var customer = r.Filter<Customer>(c => true);
        //        //var products = r.Filter<Product>(p => p.ProductName.Contains("ae"))
        //        //.OrderByDescending(p => p.ProductName);
        //        var order = r.Filter<Order>(p => true);
        //        //foreach (var P in products)
        //        //{
        //        //    Console.WriteLine($"{P.ProductName}");
        //        //}
        //        //Inne Join
        //        var ListProduct = from prod in order
        //                          join cate in customer on prod.Id equals cate.Id
        //                          select new
        //                          {
        //                              productsname = prod.OrderFullFilled,
        //                              categoriesname = cate.FirstName
        //                          };
        //        foreach (var P in ListProduct)
        //        {
        //            Console.WriteLine($"{P.productsname},{P.categoriesname}");
        //        }
        //    }

        //}

        static void SearchAndDelete()
        {
            //no eliminara si hay odenes asociadas al cliente
            //o si esta asociado a a otra tabla
            using (var R = RepositoryFactory.CreateRepository())
            {
                var P = R.Retrieve<Customer>(p => p.Id == 0);
                if (P != null)
                {
                    Console.WriteLine("cliennte: " + P.FirstName);
                    R.Delete(P);
                    Console.WriteLine("customer eliminado");
                }
                else
                {
                    Console.WriteLine("customer no encontrado");
                }
            }
        }

        static void SearchAndDeleteOrdersID()
        {
            using (var R = RepositoryFactory.CreateRepository())
            {
                var P = R.Retrieve<Order>(p => p.Id == 5);
                if (P != null)
                {
                    Console.WriteLine("orden: " + P.Id);
                    R.Delete(P);
                    Console.WriteLine("orden eliminada");
                }
                else
                {
                    Console.WriteLine("orden no encontrada");
                }
            }
        }

        /// <summary>
        /// //lo de aqui abajo solo elimina una por una y de menor a mayor ID de orden
        /// </summary>
        static void SearchAndDeleteOrdersbyCustomerID()
        {
            using (var R = RepositoryFactory.CreateRepository())
            {
                var P = R.Retrieve<Order>(p => p.Customerid == 1);
                if (P != null)
                {
                    Console.WriteLine("ordenes de customer id : " + P.Customerid);
                    R.Delete(P);
                    Console.WriteLine("ordenes eliminadas");
                }
                else
                {
                    Console.WriteLine("ordenes no encontradas");
                }
            }
        }
    }
}
