using DAL;
using Entities;
using System.Collections.Generic;
namespace BLL
{
    public class Orders
    {
        public Order Create(Order newOrder)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newOrder = r.Create(newOrder);
            }
            return newOrder;
        }

        public Order RetriveByID(int ID)
        {
            Order Resultado = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Resultado = r.Retrieve<Order>(p => p.Id == ID);
            }
            return Resultado;
        }
       
        public bool Update(Order orderToUpdate)
        {
            bool Result = false;

            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista.
                Order temp = r.Retrieve<Order>(p => p.Id == orderToUpdate.Id &&
                p.Customerid != orderToUpdate.Customerid);
                if (temp == null)
                {
                    //no existe
                    Result = r.Update(orderToUpdate);
                }
                //else
                // {
                //podemos implemetar una logica  para indica que no se pudo modifica

                // }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            ///buscar el producto para ver si tiene existencias 
            var Ordernes = RetriveByID(ID);
            if (Ordernes != null)
            {

                //eliminbar producto
                using (var r = RepositoryFactory.CreateRepository())
                {
                    Result = r.Delete(Ordernes);
                }

            }
            else
            {
                //el producto non exixte 

            }

            return Result;
        }

        public List<Order> GetOrders()
        {
            List<Order> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Order>(c => true);
            }
            return Result;
        }


        public List<Order> GetOrdersBydate(System.TimeSpan timeSpan)
        {
            List<Order> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Order>(p => p.OrderPlaced == timeSpan);
            }
            return Result;
        }
    }
}
