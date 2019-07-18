using System;
using System.Collections.Generic;
using System.Text;
using Entities;
namespace SLC
{
    public interface IService
    {
        #region Operaciones Clientes
        Customer Create(Customer newCustomer);
        Customer RetriveByID(int ID);
        bool Update(Customer customerToUpdate);
        bool Delete(int ID);
        List<Customer> FilterByCategoryID(int categoryID);
        #endregion

        #region Operaciones Orders
        Order Create(Order newOrder);
        Order RetriveByIDO(int ID);
        bool Update(Order orderToUpdate);
        bool DeleteO(int ID);
        List<Order> GetOrders();
        List<Order> GetOrdersBydate(System.TimeSpan timeSpan);
        #endregion

        #region MyRegion

        #endregion
    }

}

