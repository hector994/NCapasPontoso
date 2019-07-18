using DAL;
using Entities;
using System.Collections.Generic;
namespace BLL
{
    public class Customers
    {
        // crear un nuevo registro en la base de datos.
        public Customer Create(Customer newCustomer)
        {
            Customer Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //buscar si el nmbre del Cliente existe
                Customer res = r.Retrieve<Customer>(p => p.FirstName == newCustomer.FirstName);
                if (res == null)
                {
                    //no esxixte podemos crearlo
                    Result = r.Create(newCustomer);
                }
                else
                {
                    //Prodriamos aqui lanzar una execcion
                    //para notificar que el producto ya existe
                    //podriamos incluso crear una capa de execciones personalizadas y consumirla desde otras capas.
                    //si alguien quissiera  implementar una exaccion personalizada para ser lanzada aqui
                    throw new System.Exception();

                }
            }
            return Result;
        }

        public Customer RetriveByID(int ID)
        {
            Customer Resultado = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Resultado = r.Retrieve<Customer>(p => p.Id == ID);
            }
            return Resultado;
        }
        public bool Update(Customer customerToUpdate)
        {
            bool Result = false;

            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista.
                Customer temp = r.Retrieve<Customer>(p => p.FirstName == customerToUpdate.FirstName &&
                p.Id != customerToUpdate.Id);
                if (temp == null)
                {
                    //no existe
                    Result = r.Update(customerToUpdate);
                }
                else
                {
                    //podemos implemetar una logica  para indica que no se pudo modifica

                }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            ///buscar el producto para ver si tiene existencias 
            var Cliente = RetriveByID(ID);
            if (Cliente != null)
            {

                //eliminbar producto
                using (var r = RepositoryFactory.CreateRepository())
                {
                    Result = r.Delete(Cliente);
                }

            }
            else
            {
                //el producto non exixte 

            }

            return Result;
        }

        //public List<Customer> FilterByCategoryID(int categoryID)
        //{
        //    List<Customer> Result = null;
        //    using (var r = RepositoryFactory.CreateRepository())
        //    {
        //        Result = r.Filter<Customer>(p => p.Id == categoryID);
        //    }
        //    return Result;
        //}
    }
}
