﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderRepository : SQLDataHelper
    {
        public OrderRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) { }

        public void CreateOrder(Order order)
        {
            CustomSql(@$"INSERT INTO [dbo].[Order]
                   ([ID_user]
                   ,[Date])
             VALUES
                   ('{order.ID_user}'
                   ,'{order.Date}')");
        }
        public Order ReadOrder(Guid id_order)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE ID_order = '{id_order}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new Order(row.Field<Guid>("ID_order"), row.Field<Guid>("ID_user"), row.Field<DateTime>("Date"));
            }
            else
            {
                return null;
            }
        }

        public List<Order> ReadAllOrders()
        {
            DataTable dataTable = CustomSql($"select * from {NameTable}");
            List<Order> orders = new();
            foreach (DataRow row in dataTable.Rows)
            {
                orders.Add(new Order(row.Field<Guid>("ID_order"), row.Field<Guid>("ID_user"), row.Field<DateTime>("Date")));
            }
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            CustomSql(@$"UPDATE [dbo].[Order]
               SET [ID_user] = '{order.ID_user}'
                  ,[Date] = '{order.Date}'");
        }
        public void DeleteOrder(Order order)
        {
            CustomSql(@$"DELETE FROM [dbo].[Order]
               WHERE ID_order = '{order.ID_order}'");
        }

    }
}
