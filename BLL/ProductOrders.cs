using DAL;
using Entities;
using System.Collections.Generic;
namespace BLL
{
    public class ProductOrders
    {
        // crear un nuevo registro en la base de datos.
        public ProductOrder Create(ProductOrder newProductOrder)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newProductOrder = r.Create(newProductOrder);
            }
            return newProductOrder;
        }

        public ProductOrder RetriveByID(int ID)
        {
            ProductOrder Resultado = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Resultado = r.Retrieve<ProductOrder>(p => p.Id == ID);
            }
            return Resultado;
        }
        public bool Update(Product productorderToUpdate)
        {
            bool Result = false;

            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista.
                ProductOrder temp = r.Retrieve<ProductOrder>(p => p.Id == productorderToUpdate.Id &&
                p.Quantity != productorderToUpdate.Price);
                if (temp == null)
                {
                    //no existe
                    Result = r.Update(productorderToUpdate);
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
            var ProductOrder = RetriveByID(ID);
            if (ProductOrder != null)
            {

                //eliminbar producto
                using (var r = RepositoryFactory.CreateRepository())
                {
                    Result = r.Delete(ProductOrder);
                }

            }
            else
            {
                //el producto non exixte 

            }

            return Result;
        }

        public List<ProductOrder> FilterByQuantity(int quantity)
        {
            List<ProductOrder> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<ProductOrder>(p => p.Quantity == quantity);
            }
            return Result;
        }
    }
}
